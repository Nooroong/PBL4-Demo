using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//https://wergia.tistory.com/217 (주의: 2D 함수 써야함)

public class HouseCollisionCheck : MonoBehaviour
{
    //public GameObject day_Image;
    public Button btn; //돋보기(버튼)
    public static bool click1;
    public static bool click2;
    public Text text;
    //public TextMeshProUGUI ran1, ran2;
    public Button meal;
    public List<string> tasks = new List<string>(); //할 일
    public int index = -1;

    private string collisionObj = "null"; //주인공과 충돌한 오브젝트의 이름을 저장하는 변수
    private string[] ign_arr = { "null", "wall", "floor", "phonograph", "sofa" }; //충돌해도 버튼을 활성화 시키지 않는 오브젝트
    private string[] day1_ign_arr = { "fridge", "frontDoor", "table", "window"}; //day1일 때 충돌해도 버튼을 활성화 시키지 않는 오브젝트
    private string[] day6_ign_arr = { "fridge", "frontDoor", "table", "window", "bed" }; //day6일 때 충돌해도 버튼을 활성화 시키지 않는 오브젝트
    private List<string> ign_list = new List<string>(); //ign_arr을 리스트로 변환한 것

    void Awake()
    {
        tasks.Add("meditation");
        tasks.Add("walking");
        tasks.Add("cooking");

        //day1 day6이 아니고 랜덤1, 램덤2가 없을 경우에만 할 일 랜덤 지정
        if (PlayerPrefs.GetInt("day",-1) != 1 && PlayerPrefs.GetInt("day", -1) != 6 && !PlayerPrefs.HasKey("random1") && !PlayerPrefs.HasKey("random2"))
        {
            select_random();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        btn.interactable = false; //버튼 비활성화
        text.gameObject.SetActive(false);
        meal.gameObject.SetActive(false);

        //배열을 리스트로
        for (int i = 0; i < ign_arr.Length; i++)
            ign_list.Add(ign_arr[i]);

        if (PlayerPrefs.GetInt("day", -1) == 1) //day1일 때 bed를 제외하고 비활성화
        {
            for (int i = 0; i < day1_ign_arr.Length; i++)
                ign_list.Add(day1_ign_arr[i]);
            for (int i = 0; i < 3; i++)
                ign_list.Add(tasks[i]);
        }
        else if (PlayerPrefs.GetInt("day", -1) == 6) //day6일 때 mechanic을 제외하고 비활성화
        {
            for (int i = 0; i < day6_ign_arr.Length; i++)
                ign_list.Add(day6_ign_arr[i]);
            for (int i = 0; i < 3; i++)
                ign_list.Add(tasks[i]);
        }
        else //day2, 3, 4, 5
        {
            //밖에서 일과를 끝냈다면 활성화 되지 않도록
            if ((bool)Day_manager.GetBool("routine"))
                ign_list.Add("frontDoor");

            index = PlayerPrefs.GetInt("task_index", -1); // 랜덤으로 지정된 하지 않을 일의 인덱스를 불러옴

            ign_list.Add(tasks[index]);
            tasks.RemoveAt(index);
        }
    }

    public void select_random()
    {
        index = Random.Range(0, 3); //제외할 일 고르기

        Debug.Log(tasks[index]);

        PlayerPrefs.SetInt("task_index", index); //제외할 일 저장하기
    }

    public void BtnOnClick() {
        StartCoroutine(BtnOnClick_co(btn));
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        //충돌 시작 시
        //주인공과 충돌한 오브젝트의 이름을 저장
        collisionObj = collision.gameObject.name;
        
    }

    private void OnCollisionStay2D(Collision2D collision) {
        //충돌이 지속되는 동안
        //충돌한 오브젝트가 씬 이동과 관계있다면 버튼 활성화
        if(!ign_list.Contains(collisionObj)) btn.interactable = true;
        string s = "table";
        if (collisionObj.CompareTo(s) == 0)
        {
            if ((click1 == true) && (click2 == true))
            {
                meal.gameObject.SetActive(true);
                if(meal.gameObject.activeSelf == true)
                {
                    meal.interactable = true;
                }
                

            }
        }
    
    }
   
    public void Sleep()
    {
        SceneManager.LoadScene("House");
    }
    public void Meal()
    {
        click1 = false;
        click2 = false;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        collisionObj = "null";
        btn.interactable = false; //버튼 비활성화
        meal.interactable = false;
    }

    IEnumerator BtnOnClick_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);


        //이동할 씬 입력해주면 될듯?
        switch (collisionObj) {
            case "bed":
                if(PlayerPrefs.GetInt("day", -1) == 1) //day1 일 때 바로 잠들기
                {
                    PlayerPrefs.SetInt("sleep", 1); //잠자기 True로 전환
                    Invoke("Sleep", 1);
                }
                else
                {
                    //할 일을 다 했을 때 잠자기 (밥먹기, 약먹기, 화분가꾸기, 랜덤할 일1, 랜덤할 일2, 밖에 나갔다 오기)
                    if ((bool)Day_manager.GetBool("bap") && (bool)Day_manager.GetBool("pill") && (bool)Day_manager.GetBool("planter")
                        && (bool)Day_manager.GetBool("random1") && (bool)Day_manager.GetBool("random2") && (bool)Day_manager.GetBool("routine"))
                    {
                        PlayerPrefs.SetInt("sleep", 1); //잠자기 True로 전환
                        Invoke("Sleep", 1);
                    }
                }
                break;
            case "fridge":
                SceneManager.LoadScene("Refrigerator");
                break;
            case "cooking":
                PlayerPrefs.SetInt("Tea", 1);
                SceneManager.LoadScene("TeaTime0");
                break;
            case "frontDoor":
                if (PlayerPrefs.GetInt("day") == 2)
                {
                    PlayerPrefs.SetInt("out", 1);
                    SceneManager.LoadScene("Assistance1");
                }
                else if ( PlayerPrefs.GetInt("day") == 3)
                {
                    PlayerPrefs.SetInt("out", 1);
                    SceneManager.LoadScene("Day3_start");
                }
                else if (PlayerPrefs.GetInt("day") == 4)
                {
                    PlayerPrefs.SetInt("out", 1);
                    SceneManager.LoadScene("Day4_Start");
                }
                else if (PlayerPrefs.GetInt("day") == 5)
                {
                    PlayerPrefs.SetInt("out", 1);
                    SceneManager.LoadScene("FollowMusic");
                }
                break;
            case "meditation":
                SceneManager.LoadScene("meditation");
                break;
            case "table":
                SceneManager.LoadScene("desk");
                break;
            case "walking":
                SceneManager.LoadScene("Walking");
                break;
            case "window":
                SceneManager.LoadScene("GardenPlant");
                break;
            case "mechanic":
                SceneManager.LoadScene("Day6_PassParts");
                break;
            default:
                //혹여나 잘못 활성화 되는 경우
                break;
        }
    }
}
