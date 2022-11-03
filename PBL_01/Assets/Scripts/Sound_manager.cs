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

    int tea, Out, day, rain, bully, guitar, after_busking;
    string s_name = "";
    float fadeInTime = 2.0f;
    float fadeOutTime = 1.0f;
    int cnt = 0;
    
    private void Awake()
    {
        tea = -1;
        Out = 0;
        day = -1;
        rain = -1;
        bully = -1;
        guitar = -1;
        after_busking = -1;
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
                // ���� main, Walking, meditation, Prologue_Spaceship2, Prologue_ForcedLanding,
                // Assistance2, Siren, Shooting_game, Day4_comfort, PuzzleGame, Assistance2,
                //  Day4_Start, fight_game, Day6_Video �� ���
                if (arg0.name == bglist[i].name)
                { 
                    s_name = arg0.name;
                    BGSoundPlay(bglist[i]);
                    break;
                }
                /* PlayerPrefs.GetInt()�� �ش� ���� �ε� �Ǿ������� üũ�� */
                else if (rain != PlayerPrefs.GetInt("Rain") | tea != PlayerPrefs.GetInt("Tea") | Out != PlayerPrefs.GetInt("out") | day != PlayerPrefs.GetInt("day") //�� ���ñ�, ������ ������, ���� ���� main, Walking, meditation �̾��� ���
                   | bully != PlayerPrefs.GetInt("Bully") | guitar != PlayerPrefs.GetInt("Guitar") | after_busking != PlayerPrefs.GetInt("BuskingEnd")
                    | s_name != "")     //���� ����Ǿ ���� BGM�� ���;� �ϴ� ��.
                {
                    s_name = "";

                    /* ������ PlayerPrefs.GetInt() ���� �����Ͽ� ���� �ٲ� ������ ó������ �ٽ� ������� �ʵ��� �� */
                    tea = PlayerPrefs.GetInt("Tea");
                    Out = PlayerPrefs.GetInt("out");
                    day = PlayerPrefs.GetInt("day");
                    rain = PlayerPrefs.GetInt("Rain");
                    bully = PlayerPrefs.GetInt("Bully");
                    guitar = PlayerPrefs.GetInt("Guitar");
                    after_busking = PlayerPrefs.GetInt("BuskingEnd");

                    if (PlayerPrefs.GetInt("Tea") == 1)         // �� ����� �� �� ������ ����
                    {
                        BGSoundPlay(bglist[3]);
                    }
                    else if (PlayerPrefs.GetInt("Rain") == 1)   // Day1���� ������ ������ ���&������ ��ȭ�ϴ� ��鿡�� ������ ���Ҹ�
                    {
                        BGSoundPlay(bglist[12]);
                    }
                    else if (PlayerPrefs.GetInt("Bully") == 1) //Day4 �������� ���~ȸ�� ������ ������ ����
                    {
                        BGSoundPlay(bglist[17]);
                    }
                    else if (PlayerPrefs.GetInt("Guitar") == 1) // Day5 ����~����Ŀ ���� ������� ������ ����
                    {
                        BGSoundPlay(bglist[20]);
                    }
                    else if (PlayerPrefs.GetInt("BuskingEnd") == 1) // Day5  ����Ŀ���� ��ȭ~�� �� ������ ������ ����
                    {
                        BGSoundPlay(bglist[21]);
                    }
                    else if (PlayerPrefs.GetInt("out") == 0) // �� �ȿ��� å��, �����, ȭ�а� ���� ���� �ٲ� ���� �׸����� ������ ���
                    {
                        BGSoundPlay(bglist[0]);
                    }
                    else if (PlayerPrefs.GetInt("out") == 1) // �� ������ ������ ��
                    {
                        switch (PlayerPrefs.GetInt("day")) //�� Day �� �׸������� ���� ����Ǿ ��� ����Ǵ� ����, Day4 ����
                        {
                            case 0:                         // ���ѷα� ���� ������ ����
                                BGSoundPlay(bglist[4]);
                                break;
                            case 1:                         // ���� �ҽ���~����縦 ���� ���� ������ ������ ������ ����
                                BGSoundPlay(bglist[5]);     
                                break;
                            case 2:                         // Day2 �׸� ��
                                BGSoundPlay(bglist[6]);
                                break;
                            case 3:                         // Day3 �׸� ��
                                BGSoundPlay(bglist[7]);
                                break;
                            case 4:                         // Day4�� �׸����� Day4_Start�������� ����ǰ�, 
                                BGSoundPlay(bglist[15]);    // ���ο� ��� �� ������ ���� ������ ���� ������ �� BGM�� ���ο� ��鿡 ���̴� ����.
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
