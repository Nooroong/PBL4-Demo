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
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1) //씬이 변경할 때 사운드 변경
    {

        Debug.Log("씬 바뀜");
        cnt += 1;
        if(cnt == 1) //게임 첫 시작 사운드 페이드 아웃X
        {
            s_name = arg0.name;
            BGSoundPlay(bglist[0]);
        }
        else
        {
            for (int i = 0; i < bglist.Length; i++)
            {   // 하나의 씬에서만 재생되는 음악은 씬과 음악의 이름이 동일할 때 재생되도록 함.
                // 씬이 main, Walking, meditation, Prologue_Spaceship2, Prologue_ForcedLanding,
                // Assistance2, Siren, Shooting_game, Day4_comfort, PuzzleGame, Assistance2,
                //  Day4_Start, fight_game, Day6_Video 일 경우
                if (arg0.name == bglist[i].name)
                { 
                    s_name = arg0.name;
                    BGSoundPlay(bglist[i]);
                    break;
                }
                /* PlayerPrefs.GetInt()로 해당 씬이 로드 되었는지를 체크함 */
                else if (rain != PlayerPrefs.GetInt("Rain") | tea != PlayerPrefs.GetInt("Tea") | Out != PlayerPrefs.GetInt("out") | day != PlayerPrefs.GetInt("day") //차 마시기, 밖으로 나가기, 이전 씬이 main, Walking, meditation 이었을 경우
                   | bully != PlayerPrefs.GetInt("Bully") | guitar != PlayerPrefs.GetInt("Guitar") | after_busking != PlayerPrefs.GetInt("BuskingEnd")
                    | s_name != "")     //씬이 변경되어도 같은 BGM이 나와야 하는 곳.
                {
                    s_name = "";

                    /* 변수에 PlayerPrefs.GetInt() 값을 저장하여 씬이 바뀌어도 음악이 처음부터 다시 재생되지 않도록 함 */
                    tea = PlayerPrefs.GetInt("Tea");
                    Out = PlayerPrefs.GetInt("out");
                    day = PlayerPrefs.GetInt("day");
                    rain = PlayerPrefs.GetInt("Rain");
                    bully = PlayerPrefs.GetInt("Bully");
                    guitar = PlayerPrefs.GetInt("Guitar");
                    after_busking = PlayerPrefs.GetInt("BuskingEnd");

                    if (PlayerPrefs.GetInt("Tea") == 1)         // 차 만들기 할 때 나오는 음악
                    {
                        BGSoundPlay(bglist[3]);
                    }
                    else if (PlayerPrefs.GetInt("Rain") == 1)   // Day1에서 정비사와 만나는 장면&정비사와 대화하는 장면에서 나오는 빗소리
                    {
                        BGSoundPlay(bglist[12]);
                    }
                    else if (PlayerPrefs.GetInt("Bully") == 1) //Day4 괴롭히는 장면~회상 끝까지 나오는 음악
                    {
                        BGSoundPlay(bglist[17]);
                    }
                    else if (PlayerPrefs.GetInt("Guitar") == 1) // Day5 시작~버스커 음악 감상까지 나오는 음악
                    {
                        BGSoundPlay(bglist[20]);
                    }
                    else if (PlayerPrefs.GetInt("BuskingEnd") == 1) // Day5  버스커와의 대화~집 갈 때까지 나오는 음악
                    {
                        BGSoundPlay(bglist[21]);
                    }
                    else if (PlayerPrefs.GetInt("out") == 0) // 집 안에서 책상, 냉장고, 화분과 같이 씬이 바뀌어도 메인 테마곡이 나오는 경우
                    {
                        BGSoundPlay(bglist[0]);
                    }
                    else if (PlayerPrefs.GetInt("out") == 1) // 집 밖으로 나갔을 때
                    {
                        switch (PlayerPrefs.GetInt("day")) //각 Day 별 테마곡으로 씬이 변경되어도 계속 재생되는 음악, Day4 제외
                        {
                            case 0:                         // 프롤로그 동안 나오는 음악
                                BGSoundPlay(bglist[4]);
                                break;
                            case 1:                         // 지구 불시착~정비사를 만나 집에 들어오기 전까지 나오는 음악
                                BGSoundPlay(bglist[5]);     
                                break;
                            case 2:                         // Day2 테마 곡
                                BGSoundPlay(bglist[6]);
                                break;
                            case 3:                         // Day3 테마 곡
                                BGSoundPlay(bglist[7]);
                                break;
                            case 4:                         // Day4의 테마곡은 Day4_Start씬에서만 재생되고, 
                                BGSoundPlay(bglist[15]);    // 말싸움 장면 두 씬에서 같은 음악을 쓰기 때문에 이 BGM은 말싸움 장면에 쓰이는 음악.
                                break;
                        }


                    }
                }
            }
        }



    }
    public void SFXPlay(string sfxName, AudioClip clip) // 효과음 재생 함수
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
