using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://rito15.github.io/posts/unity-android-toast-message/
/*
 * <�̱���>
 * ��ü�� ������ ������ �ʿ� ���� �� �� ���� �����ϸ� �Ǵ� ��쿡 ����Ѵ�.
 * ���� ���۵� �� ���� �ѹ��� �޸𸮸� �Ҵ��ϰ� �ű⿡ �ν��Ͻ��� ����� ����ϴ� ����������.
 * 
 */


public class AndroidToast : MonoBehaviour
{
    #region Singleton

    //�̱��� �ν��Ͻ� Getter
    public static AndroidToast I {
        get {
            if (instance == null)    // üũ 1 : �ν��Ͻ��� ���� ���
                CheckExsistence();

            return instance;
        }
    }

    // �̱��� �ν��Ͻ�
    private static AndroidToast instance;

    // �̱��� �ν��Ͻ� ���� ���� Ȯ�� (üũ 2)
    private static void CheckExsistence() {
        // �̱��� �˻�
        instance = FindObjectOfType<AndroidToast>();

        // �ν��Ͻ� ���� ������Ʈ�� �������� ���� ���, �� ������Ʈ�� ���Ƿ� �����Ͽ� �ν��Ͻ� �Ҵ�
        if (instance == null) {
            // �� ���� ������Ʈ ����
            GameObject container = new GameObject("AndroidToast Singleton Container");

            // ���� ������Ʈ�� Ŭ���� ������Ʈ �߰� �� �ν��Ͻ� �Ҵ�
            instance = container.AddComponent<AndroidToast>();
        }
    }

    private void CheckInstance() {
        // �̱��� �ν��Ͻ��� �������� �ʾ��� ���, �������� �ʱ�ȭ
        if (instance == null)
            instance = this;

        // �̱��� �ν��Ͻ��� �����ϴµ�, ������ �ƴ� ���, ������(������Ʈ)�� �ı�
        if (instance != null && instance != this) {
            Debug.Log("�̹� AndroidToast �̱����� �����ϹǷ� ������Ʈ�� �ı��մϴ�.");
            Destroy(this);

            // ���� ���� ������Ʈ�� ������Ʈ�� �ڽŸ� �־��ٸ�, ���� ������Ʈ�� �ı�
            var components = gameObject.GetComponents<Component>();

            if (components.Length <= 2)
                Destroy(gameObject);
        }
    }

    private void Awake() {
        CheckInstance();
    }

    #endregion // ==================================================================

    public enum ToastLength {
        /// <summary> �� 2.5�� </summary>
        Short,
        /// <summary> �� 4�� </summary>
        Long
    };

#if UNITY_EDITOR
    private float __editorGuiTime = 0f;
    private string __editorGuiMessage;

#elif UNITY_ANDROID

    private AndroidJavaClass _unityPlayer;
    private AndroidJavaObject _unityActivity;
    private AndroidJavaClass _toastClass;

    private void Start()
    {
        _unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        _unityActivity = _unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        _toastClass = new AndroidJavaClass("android.widget.Toast");
    }
#endif

    /// <summary> �ȵ���̵� �佺Ʈ �޽��� ǥ���ϱ� </summary>
    [System.Diagnostics.Conditional("UNITY_ANDROID")]
    public void ShowToastMessage(string message, ToastLength length = ToastLength.Short) {
#if UNITY_EDITOR
        __editorGuiTime = length == ToastLength.Short ? 2.5f : 4f;
        __editorGuiMessage = message;

#elif UNITY_ANDROID
        if (_unityActivity != null)
        {
            _unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = _toastClass.CallStatic<AndroidJavaObject>("makeText", _unityActivity, message, (int)length);
                toastObject.Call("show");
            }));
        }
#endif
    }

#if UNITY_EDITOR
    /* ����Ƽ ������ IMGUI�� ���� �佺Ʈ �޽��� ǥ�� ����ϱ� */

    private GUIStyle toastStyle;
    private void OnGUI() {
        if (__editorGuiTime <= 0f) return;

        int width = (int)(Screen.width * 0.5f);
        int height = (int)(Screen.height * 0.08f);
        Rect rect = new Rect((Screen.width - width) * 0.5f, Screen.height * 0.8f, width, height);

        if (toastStyle == null) {
            toastStyle = new GUIStyle(GUI.skin.box);
            toastStyle.fontSize = UnityEngine.Screen.width / 100;
            toastStyle.fontStyle = FontStyle.Bold;
            toastStyle.alignment = TextAnchor.MiddleCenter;
            toastStyle.normal.textColor = Color.white;
            toastStyle.normal.background = MakeTex(width, height, new Color(0f, 0f, 0f, 0.5f));
        }

        GUI.Box(rect, __editorGuiMessage, toastStyle);
    }
    private void Update() {
        if (__editorGuiTime > 0f)
            __editorGuiTime -= Time.unscaledDeltaTime;
    }
#endif


    //https://forum.unity.com/threads/change-gui-box-color.174609/
    public static Texture2D MakeTex(int width, int height, Color col) {
        Color[] pix = new Color[width * height];
        for(int i = 0; i < pix.Length; i++) {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
}
