/*
 참고 링크:
https://www.youtube.com/watch?v=wkypEC294K8 (원본 강의 영상)
https://pastebin.com/xRdFU8Pm (소스코드)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LockPattern : MonoBehaviour {
    public Image Panel;
    public Image Background;

    float time = 0f;
    float F_time = 1f;

    public GameObject linePrefab;
    public GameObject lineParent; //라인이 캔버스의 자식으로 생성됨
    public List<CircleIdentifier> lines = new List<CircleIdentifier>(); //CircleIdentifier: 각 라인이 어느 circle로부터 생성됐는지 알 수 있음.

    bool isAsc = true; //좌->우 패턴
    bool isDes = true; //우->좌 패턴

    GameObject lineOnEdit; //가장 마지막에 생성된 라인을 담는 변수
    RectTransform lineOnEditRcTs;
    CircleIdentifier circleOnEdit; //마지막 라인이 생성된 원의 정보
    Dictionary<int, CircleIdentifier> circles = new Dictionary<int, CircleIdentifier>();

    bool unLocking; //잠금해제 상태를 저장하는 변수
    bool enable = true;
    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < transform.childCount; i++) {
            var circle = transform.GetChild(i);
            var identifier = circle.GetComponent<CircleIdentifier>();
            identifier.id = i;
            circles.Add(i, identifier);
        }
    }

    // Update is called once per frame
    void Update() {
        if (!enable) {
            return;
        }

        //항상 가장 마지막에 생성된 라인은 마우스를 따라다닌다. 따라서 Update()에서 처리.
        if (unLocking) {
            Vector3 mousePos = lineParent.transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint((Input.mousePosition)));
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, (Vector3.Distance(mousePos, circleOnEdit.transform.localPosition)));
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(Vector3.up, (mousePos - circleOnEdit.transform.localPosition).normalized);
        }
    }

    IEnumerator Release() {
        enable = false;

        yield return new WaitForSeconds(3);

        foreach (var circle in circles) {
            circle.Value.GetComponent<Image>().DOColor(Color.white, .25F);
            circle.Value.GetComponent<RectTransform>().DOScale(1f, .5f).SetEase(Ease.OutBounce);
        }

        foreach (var line in lines) {
            Destroy(line.gameObject);
        }

        lines.Clear();
        lineOnEdit = null;
        lineOnEditRcTs = null;
        circleOnEdit = null;

        enable = true;
    }

    GameObject CreateLine(Vector3 pos, int id) {
        //원들의 부모 오브젝트 좌표가 (0, 0, 0)인지 확인. 아니면 선이 이상하게 그려질 수 있음.
        var line = GameObject.Instantiate(linePrefab, lineParent.transform); //라인프리팹 복제
        line.transform.localPosition = pos; //라인의 생성 위치는 클릭된 원의 중점
        var linedf = line.AddComponent<CircleIdentifier>();
        linedf.id = id; //라인의 id == 라인이 생성된 원의 id
        lines.Add(linedf);
        return line;
    }
    void TrySetLineEdit(CircleIdentifier circle) {
        //클릭된 원에서 이미 생성된 라인이 있는지 검사.
        foreach (var line in lines) {
            if (line.id == circle.id) { //해당 원에 이미 라인이 생성됐다면
                return; //라인을 새로 생성하지 않음.
            }
        }

        lineOnEdit = CreateLine(circle.transform.localPosition, circle.id);
        lineOnEditRcTs = lineOnEdit.GetComponent<RectTransform>();
        circleOnEdit = circle;
    }

    bool IsCorrect(List<CircleIdentifier> a) {
        if (a.Count != transform.childCount) return false;

        for (int i = 0; i < a.Count - 1; i++) {
            if (a[i].id < a[i + 1].id && isAsc) {
                isAsc = true; isDes = false;
            } else if (a[i].id > a[i + 1].id && isDes) {
                isAsc = false; isDes = true;
            } else
                return false;
        }
        return true;
    }

    public void OnMouseEnterCircle(CircleIdentifier idf) {
        if (!enable) {
            return;
        }
        if (unLocking) {
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(circleOnEdit.transform.localPosition, idf.transform.localPosition));
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(Vector3.up, (idf.transform.localPosition - circleOnEdit.transform.localPosition).normalized);
            TrySetLineEdit(idf);
            StartCoroutine(UntilPlayback(idf));
            circles[idf.id].GetComponent<RectTransform>().DOScale(1.2f, .5f).SetEase(Ease.OutBounce);
        }
    }
    public void OnMouseExitCircle(CircleIdentifier idf) {
        if (!enable) {
            return;
        }
        StartCoroutine(OnMouseExitCircle(idf.id));
    }

    IEnumerator OnMouseExitCircle(int _idf) {
        yield return new WaitForSeconds(.5f);
        circles[_idf].GetComponent<RectTransform>().DOScale(1f, .5f).SetEase(Ease.OutBounce);
    }

    public void OnMouseDownCircle(CircleIdentifier idf) {
        if (!enable) {
            return;
        }
        unLocking = true;
        TrySetLineEdit(idf);
    }
    public void OnMouseUpCircle(CircleIdentifier idf) {
        if (!enable) {
            return;
        }
        if (unLocking) {
            //패턴 일치
            if (IsCorrect(lines)) {
                foreach (var item in lines) {
                    circles[item.id].GetComponent<Image>().DOColor(Color.green, .25F);
                }

                Destroy(lines[lines.Count - 1].gameObject);
                lines.RemoveAt(lines.Count - 1);

                foreach (var item in lines) {
                    item.GetComponent<Image>().DOColor(Color.green, .25F);
                }

                Invoke("F_Out", 1f);
            } else {
                //패턴 불일치
                foreach (var item in lines) {
                    circles[item.id].GetComponent<Image>().DOColor(Color.red, .25F);
                    circles[item.id].GetComponent<AudioSource>().enabled = true;
                }

                Destroy(lines[lines.Count - 1].gameObject);
                lines.RemoveAt(lines.Count - 1);

                foreach (var item in lines) {
                    item.GetComponent<Image>().DOColor(Color.red, .25F);
                }

                StartCoroutine(Release());
            }


        }
        unLocking = false;
    }



    public void F_Out() {
        StartCoroutine(FadeOutFlow());
    }

    IEnumerator FadeOutFlow() {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;

        while (alpha.a < 1f) {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
        NextScene();
    }


    void NextScene() {
        SceneManager.LoadScene("Treatment");
    }


    IEnumerator UntilPlayback(CircleIdentifier idf)
    {
        circles[idf.id].GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !circles[idf.id].GetComponent<AudioSource>().isPlaying);
        circles[idf.id].GetComponent<AudioSource>().enabled = false;
    }
}