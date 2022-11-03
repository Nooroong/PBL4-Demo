using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://rito15.github.io/posts/unity-android-toast-message/

public class GameExit : MonoBehaviour
{
    private int width = (int)(Screen.width * 0.5f);
    private int height = (int)(Screen.height * 0.5f);
    // private float time = 0f;
    // private float F_time = 2f;

    private void Awake() {
        AndroidToast instance;
        GameObject container = new GameObject("AndroidToast Singleton Container");
        instance = container.AddComponent<AndroidToast>();
    }

#if UNITY_ANDROID
    private bool _preparedToQuit = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (_preparedToQuit == false) {
                AndroidToast.I.ShowToastMessage("뒤로가기 버튼을 한 번 더 누르면 종료됩니다.");
                PrepareToQuit();
            } else {
                Debug.Log("Quit");
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }
        }
    }

    private void PrepareToQuit() {
        StartCoroutine(PrepareToQuitRoutine());
    }

    private IEnumerator PrepareToQuitRoutine() {
        _preparedToQuit = true;
        yield return new WaitForSecondsRealtime(2.5f);
        _preparedToQuit = false;
    }
#endif

}