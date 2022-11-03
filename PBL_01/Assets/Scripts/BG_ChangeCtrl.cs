using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BG_ChangeCtrl : MonoBehaviour
{
    public Image[] change_Img; // 다음에 보여질 이미지 목록들(Black은 제외)
    public float[] view_time; // 한 이미지가 보여질 시간 (2.5f)
    public Button Btn; // 다음 씬으로 넘어가는 버튼

    float time = 0f;
    float F_time = 1.2f;
    

    private void Awake() {
        for(int i = 1; i < change_Img.Length; i++) {
            change_Img[i].gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 순서대로 다음 이미지들의 투명도를 조절한다.
        StartCoroutine(FadeOutFlow(change_Img, view_time));

    }


    IEnumerator FadeOutFlow(Image[] img, float[] view_time)
    {
        for(int i = 0; i < img.Length-1; i++) {
            if (i < view_time.Length) {
                yield return new WaitForSeconds(view_time[i]);
            } else {
                yield return new WaitForSeconds(2.5f);
            }
            

            img[i+1].gameObject.SetActive(true);
            time = 0f;
            Color alpha = img[i+1].color;

            while (alpha.a < 1f)
            {
                time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(0, 1, time);

                // 부모
                img[i+1].color = alpha;
                // 자식
                for(int j = 0; j < img[i+1].transform.childCount; j++) {
                    img[i+1].transform.GetChild(j).GetComponent<Image>().color = alpha;
                }
                
                yield return null;
            }
        }
        // 마지막 이미지까지 나오고 버튼 등장시키기
        // 버튼 누르면 다음 씬으로 넘어감
        if (Btn) {
            Btn.gameObject.SetActive(true);
        }
    }
}
