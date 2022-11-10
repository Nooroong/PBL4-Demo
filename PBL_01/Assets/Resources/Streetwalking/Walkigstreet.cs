using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Walkigstreet : MonoBehaviour
{
    public Camera m_cam;

    public GameObject tree, building, sky, fly;
    Vector3 P_screenPos, F_screenPos;

    Animator m_Animator;

    float time = 0f;
    float F_time = 4f;
    float p_speed = 200f;
    float xMove;
    public Image player;

    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        P_screenPos = m_cam.WorldToScreenPoint(player.gameObject.transform.position);
        F_screenPos = m_cam.WorldToScreenPoint(fly.gameObject.transform.position);
        walking();
    }

    // Update is called once per frame
    void Update()
    {
        P_screenPos = m_cam.WorldToScreenPoint(player.gameObject.transform.position);
        Debug.Log(F_screenPos.x - P_screenPos.x);
        F_screenPos = m_cam.WorldToScreenPoint(fly.gameObject.transform.position);
        time += Time.deltaTime / F_time;
    }
    public void walking()
    {
        StartCoroutine(WalkingFlow());
    }

    IEnumerator WalkingFlow()
    {
        // F_screenPos.x - P_screenPos.x > 400
        while (this.gameObject.GetComponent<RectTransform>().anchoredPosition.x <
                fly.gameObject.GetComponent<RectTransform>().anchoredPosition.x - 300f)
        {
            xMove = 0;
            xMove = 2/p_speed;
            player.transform.Translate(new Vector3(xMove, 0, 0));
            yield return null;
        }
        m_Animator.GetComponent<Animator>().enabled = false;
        tree.gameObject.GetComponent<BG_Moving>().enabled = false;
        sky.gameObject.GetComponent<BG_Moving>().enabled = false;
        building.gameObject.GetComponent<BG_Moving>().enabled = false;
        fly.gameObject.GetComponent<BG_Moving>().enabled = false;
        Invoke("LoadScene", 2f);
        yield return null;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("StreetLeaflet");
    }
}
