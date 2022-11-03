using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

//https://wergia.tistory.com/217 (����: 2D �Լ� �����)

public class HouseCollisionCheck : MonoBehaviour
{
    //public GameObject day_Image;
    public Button btn; //������(��ư)
    public static bool click1;
    public static bool click2;
    public Text text;
    //public TextMeshProUGUI ran1, ran2;
    public Button meal;
    public List<string> tasks = new List<string>(); //�� ��
    public int index = -1;

    private string collisionObj = "null"; //���ΰ��� �浹�� ������Ʈ�� �̸��� �����ϴ� ����
    private string[] ign_arr = { "null", "wall", "floor", "phonograph", "sofa" }; //�浹�ص� ��ư�� Ȱ��ȭ ��Ű�� �ʴ� ������Ʈ
    private string[] day1_ign_arr = { "fridge", "frontDoor", "table", "window"}; //day1�� �� �浹�ص� ��ư�� Ȱ��ȭ ��Ű�� �ʴ� ������Ʈ
    private string[] day6_ign_arr = { "fridge", "frontDoor", "table", "window", "bed" }; //day6�� �� �浹�ص� ��ư�� Ȱ��ȭ ��Ű�� �ʴ� ������Ʈ
    private List<string> ign_list = new List<string>(); //ign_arr�� ����Ʈ�� ��ȯ�� ��

    void Awake()
    {
        tasks.Add("meditation");
        tasks.Add("walking");
        tasks.Add("cooking");

        //day1 day6�� �ƴϰ� ����1, ����2�� ���� ��쿡�� �� �� ���� ����
        if (PlayerPrefs.GetInt("day",-1) != 1 && PlayerPrefs.GetInt("day", -1) != 6 && !PlayerPrefs.HasKey("random1") && !PlayerPrefs.HasKey("random2"))
        {
            select_random();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        btn.interactable = false; //��ư ��Ȱ��ȭ
        text.gameObject.SetActive(false);
        meal.gameObject.SetActive(false);

        //�迭�� ����Ʈ��
        for (int i = 0; i < ign_arr.Length; i++)
            ign_list.Add(ign_arr[i]);

        if (PlayerPrefs.GetInt("day", -1) == 1) //day1�� �� bed�� �����ϰ� ��Ȱ��ȭ
        {
            for (int i = 0; i < day1_ign_arr.Length; i++)
                ign_list.Add(day1_ign_arr[i]);
            for (int i = 0; i < 3; i++)
                ign_list.Add(tasks[i]);
        }
        else if (PlayerPrefs.GetInt("day", -1) == 6) //day6�� �� mechanic�� �����ϰ� ��Ȱ��ȭ
        {
            for (int i = 0; i < day6_ign_arr.Length; i++)
                ign_list.Add(day6_ign_arr[i]);
            for (int i = 0; i < 3; i++)
                ign_list.Add(tasks[i]);
        }
        else //day2, 3, 4, 5
        {
            //�ۿ��� �ϰ��� ���´ٸ� Ȱ��ȭ ���� �ʵ���
            if ((bool)Day_manager.GetBool("routine"))
                ign_list.Add("frontDoor");

            index = PlayerPrefs.GetInt("task_index", -1); // �������� ������ ���� ���� ���� �ε����� �ҷ���

            ign_list.Add(tasks[index]);
            tasks.RemoveAt(index);
        }
    }

    public void select_random()
    {
        index = Random.Range(0, 3); //������ �� ����

        Debug.Log(tasks[index]);

        PlayerPrefs.SetInt("task_index", index); //������ �� �����ϱ�
    }

    public void BtnOnClick() {
        StartCoroutine(BtnOnClick_co(btn));
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        //�浹 ���� ��
        //���ΰ��� �浹�� ������Ʈ�� �̸��� ����
        collisionObj = collision.gameObject.name;
        
    }

    private void OnCollisionStay2D(Collision2D collision) {
        //�浹�� ���ӵǴ� ����
        //�浹�� ������Ʈ�� �� �̵��� �����ִٸ� ��ư Ȱ��ȭ
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
        btn.interactable = false; //��ư ��Ȱ��ȭ
        meal.interactable = false;
    }

    IEnumerator BtnOnClick_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);


        //�̵��� �� �Է����ָ� �ɵ�?
        switch (collisionObj) {
            case "bed":
                if(PlayerPrefs.GetInt("day", -1) == 1) //day1 �� �� �ٷ� ����
                {
                    PlayerPrefs.SetInt("sleep", 1); //���ڱ� True�� ��ȯ
                    Invoke("Sleep", 1);
                }
                else
                {
                    //�� ���� �� ���� �� ���ڱ� (��Ա�, ��Ա�, ȭ�а��ٱ�, ������ ��1, ������ ��2, �ۿ� ������ ����)
                    if ((bool)Day_manager.GetBool("bap") && (bool)Day_manager.GetBool("pill") && (bool)Day_manager.GetBool("planter")
                        && (bool)Day_manager.GetBool("random1") && (bool)Day_manager.GetBool("random2") && (bool)Day_manager.GetBool("routine"))
                    {
                        PlayerPrefs.SetInt("sleep", 1); //���ڱ� True�� ��ȯ
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
                //Ȥ���� �߸� Ȱ��ȭ �Ǵ� ���
                break;
        }
    }
}
