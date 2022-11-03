using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://keykat7.blogspot.com/2020/01/unity-rectTransform.html

public class MusicNoteCtrl : MonoBehaviour
{
    public Button[] btn;

    private int btn_index = 0;
    private int[] note_pos_arr = {-440, -120, 140, 430, 720};
    private float xVelocity = 0;
    
    

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < btn.Length; i++) {
            btn[i].interactable = false;
        }
    }

    void Start()
    {
        // 음표들이 오른쪽에서 차례대로 날아옴
        StartCoroutine(NoteMove(note_pos_arr));
    }


    public void NoteClick() {
        StartCoroutine(NoteClick_Coroutine());
    }


    IEnumerator NoteMove(int[] pos_x) {
        for(int i = 0; i < btn.Length; i++) {
            Vector2 tmp_pos = new Vector3(pos_x[i],
                                          btn[i].GetComponent<RectTransform>().anchoredPosition.y);
            
            while(btn[i].GetComponent<RectTransform>().anchoredPosition.x > tmp_pos.x+20) {
                float newX = Mathf.SmoothDamp(btn[i].GetComponent<RectTransform>().anchoredPosition.x, tmp_pos.x, ref xVelocity, 0.3f);
                btn[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(newX, btn[i].GetComponent<RectTransform>().anchoredPosition.y);
                yield return null;
            }

            yield return null;

        }

        // 첫번째 음표만 interactable 활성화
        btn[0].interactable = true;

        yield return null;
    }


    IEnumerator NoteClick_Coroutine() {
        // 클릭 소리 재생
        btn[btn_index].GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !btn[btn_index].GetComponent<AudioSource>().isPlaying);
        
        // 클릭한 버튼 이미지 감추기
        btn[btn_index].GetComponent<Image>().enabled = false;

        // 주인공 이동
        while (this.GetComponent<RectTransform>().anchoredPosition.x < btn[btn_index].GetComponent<RectTransform>().anchoredPosition.x - 50) {
            float newX = Mathf.SmoothDamp(this.GetComponent<RectTransform>().anchoredPosition.x, btn[btn_index].GetComponent<RectTransform>().anchoredPosition.x, ref xVelocity, 0.7f);
            this.GetComponent<RectTransform>().anchoredPosition = new Vector2(newX, this.GetComponent<RectTransform>().anchoredPosition.y);
            yield return null;
        }

        // 클릭한 버튼 오브젝트 삭제
        btn[btn_index].gameObject.SetActive(false);
        
        // 다음 버튼 interactable 활성화 (index 오류 생각)
        if(++btn_index < btn.Length) {
            btn[btn_index].interactable = true;  
        }


        yield return null;
    }
}
