using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaybackNBtn : MonoBehaviour
{   
    //효과음 재생 뒤에 오브젝트 비활성화
    public IEnumerator Destory_Btn(GameObject obj) {
        yield return new WaitForSeconds(0.15f);
        if(!obj.GetComponent<AudioSource>().isPlaying)
            obj.gameObject.SetActive(false);            
    }
}
