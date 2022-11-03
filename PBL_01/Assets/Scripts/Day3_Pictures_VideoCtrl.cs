using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Day3_Pictures_VideoCtrl : MonoBehaviour
{
    public RawImage mScreen = null;
    public VideoPlayer mVideoPlayer = null;
    public Image Panel;

    float time = 0f;
    float F_time = 1f;
    
    void Start() {
        Panel.gameObject.SetActive(false);

        if (mScreen != null && mVideoPlayer != null) {
            mVideoPlayer.loopPointReached += CheckOver; //영상 끝났는지 확인(https://mentum.tistory.com/170)
            // 비디오 준비 코루틴 호출
            StartCoroutine(PrepareVideo());
        }
    }

    protected IEnumerator PrepareVideo() {
        // 비디오 준비
        mVideoPlayer.Prepare();

        // 비디오가 준비되는 것을 기다림
        while (!mVideoPlayer.isPrepared) {
            yield return new WaitForSeconds(0.5f);
        }

        // VideoPlayer의 출력 texture를 RawImage의 texture로 설정한다
        mScreen.texture = mVideoPlayer.texture;
    }

    public void PlayVideo() {
        if (mVideoPlayer != null && mVideoPlayer.isPrepared) {
            // 비디오 재생
            mVideoPlayer.Play();
        }
    }

    public void StopVideo() {
        if (mVideoPlayer != null && mVideoPlayer.isPrepared) {
            // 비디오 멈춤
            mVideoPlayer.Stop();
        }
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp) {
        Invoke("F_Out", 0.5f); //영상 끝나면 다음 씬으로 넘어감
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
        SceneManager.LoadScene("Day3_Pass");
    }
}
