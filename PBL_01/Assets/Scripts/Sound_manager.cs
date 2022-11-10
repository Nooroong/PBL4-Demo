using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sound_manager : MonoBehaviour
{
    public Button n_btn, c_btn;
    public AudioSource BgSource;
    public AudioClip[] bglist;
    public static Sound_manager instance;

    int Out, day, rain;
    string s_name = "";
    float fadeInTime = 2.0f;
    float fadeOutTime = 1.0f;
    int cnt = 0;
    
    private void Awake()
    {
        Out = 0;
        day = -1;
        rain = -1;

        if (instance== null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;       
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1) //���� ������ �� ���� ����
    {

        Debug.Log("�� �ٲ�");
        cnt += 1;
        if(cnt == 1) //���� ù ���� ���� ���̵� �ƿ�X
        {
            s_name = arg0.name;
            BGSoundPlay(bglist[0]);
        }
        else
        {
            for (int i = 0; i < bglist.Length; i++)
            {   // �ϳ��� �������� ����Ǵ� ������ ���� ������ �̸��� ������ �� ����ǵ��� ��.
                // ���� main, Prologue_Spaceship2, Prologue_ForcedLanding �� ���
                if (arg0.name == bglist[i].name)
                { 
                    s_name = arg0.name;
                    BGSoundPlay(bglist[i]);
                    break;
                }
                /* PlayerPrefs.GetInt()�� �ش� ���� �ε� �Ǿ������� üũ�� */
                else if (rain != PlayerPrefs.GetInt("Rain") |  Out != PlayerPrefs.GetInt("out") | day != PlayerPrefs.GetInt("day") 
                    //���� ���� main �̾��� ���
                    | s_name != "")     //���� ����Ǿ ���� BGM�� ���;� �ϴ� ��.
                {
                    s_name = "";

                    /* ������ PlayerPrefs.GetInt() ���� �����Ͽ� ���� �ٲ� ������ ó������ �ٽ� ������� �ʵ��� �� */
                    Out = PlayerPrefs.GetInt("out");
                    day = PlayerPrefs.GetInt("day");
                    rain = PlayerPrefs.GetInt("Rain");

                    if (PlayerPrefs.GetInt("Rain") == 1)   // Day1���� ������ ������ ���&������ ��ȭ�ϴ� ��鿡�� ������ ���Ҹ�
                    {
                        BGSoundPlay(bglist[5]);
                    }
                    else if (PlayerPrefs.GetInt("out") == 1) // �� ������ ������ ��
                    {
                        switch (PlayerPrefs.GetInt("day")) //�� Day �� �׸������� ���� ����Ǿ ��� ����Ǵ� ����, Day4 ����
                        {
                            case 0:                         // ���ѷα� ���� ������ ����
                                BGSoundPlay(bglist[1]);
                                break;
                            case 1:                         // ���� �ҽ���~����縦 ���� ���� ������ ������ ������ ����
                                BGSoundPlay(bglist[2]);     
                                break;
                        }


                    }
                }
            }
        }



    }
    public void SFXPlay(string sfxName, AudioClip clip) // ȿ���� ��� �Լ�
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource =  go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BGSoundPlay(AudioClip clip)
    {
        BgSource.clip = clip;
        BgSource.loop = true;
        StartCoroutine(Audio_F.FadeIn(BgSource, fadeInTime));
    }
}
