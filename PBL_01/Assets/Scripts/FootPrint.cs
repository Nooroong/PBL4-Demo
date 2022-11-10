using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FootPrint : MonoBehaviour
{
    Animator m_Animator;
    public Button Foot1, Foot2, Foot3, Foot4, Foot5;
    float speed = 5f;
    float xMove;
    public Image player;
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player.gameObject.SetActive(true);
        m_Animator = GetComponent<Animator>();
        m_Animator.GetComponent<Animator>().enabled = false;

        Foot2.GetComponent<Button>().enabled = false;
        Foot3.GetComponent<Button>().enabled = false;
        Foot4.GetComponent<Button>().enabled = false;
        Foot5.GetComponent<Button>().enabled = false;
    }

    public void FadeFoot1()
    {
        StartCoroutine(Foot1Flow());
    }

    IEnumerator Foot1Flow()
    {
        Foot1.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !Foot1.GetComponent<AudioSource>().isPlaying);

        // player.gameObject.transform.position.x < 570.0f
        while (player.gameObject.transform.position.x < Foot1.gameObject.transform.position.x - 50)
        {
            m_Animator.GetComponent<Animator>().enabled = true;
            Foot1.gameObject.SetActive(false);
            xMove = 0;
            xMove = +speed;
            player.transform.Translate(new Vector3(xMove, 0, 0));
            yield return null;
        }

        Foot2.GetComponent<Button>().enabled = true;
        yield return null;
    }

    public void FadeFoot2()
    {
        StartCoroutine(Foot2Flow());
    }

    IEnumerator Foot2Flow()
    {
        Foot2.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !Foot2.GetComponent<AudioSource>().isPlaying);
        
        // (player.gameObject.transform.position.x > 570.0f) && (player.gameObject.transform.position.x < 760.0f)
        while (player.gameObject.transform.position.x < Foot2.gameObject.transform.position.x - 50)
        {
            m_Animator.GetComponent<Animator>().enabled = true;
            Foot2.gameObject.SetActive(false);
            xMove = 0;
            xMove = +speed;
            player.transform.Translate(new Vector3(xMove, 0, 0));
            yield return null;
        }

        Foot3.GetComponent<Button>().enabled = true;
        yield return null;
    }
    public void FadeFoot3()
    {
        StartCoroutine(Foot3Flow());
    }

    IEnumerator Foot3Flow()
    {
        Foot3.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !Foot3.GetComponent<AudioSource>().isPlaying);
        
        // (player.gameObject.transform.position.x > 750.0f) && (player.gameObject.transform.position.x < 880.0f)
        while (player.gameObject.transform.position.x < Foot3.gameObject.transform.position.x - 50)
        {
            m_Animator.GetComponent<Animator>().enabled = true;
            Foot3.gameObject.SetActive(false);
            xMove = 0;
            xMove = +speed;
            player.transform.Translate(new Vector3(xMove, 0, 0));
            yield return null;
        }

        Foot4.GetComponent<Button>().enabled = true;
        yield return null;
    }
    public void FadeFoot4()
    {
        StartCoroutine(Foot4Flow());
    }

    IEnumerator Foot4Flow()
    {
        Foot4.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !Foot4.GetComponent<AudioSource>().isPlaying);
        
        // (player.gameObject.transform.position.x > 880.0f) && (player.gameObject.transform.position.x < 1100.0f)
        while (player.gameObject.transform.position.x < Foot4.gameObject.transform.position.x - 50)
        {
            m_Animator.GetComponent<Animator>().enabled = true;
            Foot4.gameObject.SetActive(false);
            xMove = 0;
            xMove = +speed;
            player.transform.Translate(new Vector3(xMove, 0, 0));
            yield return null;
        }

        Foot5.GetComponent<Button>().enabled = true;
        yield return null;
    }

    public void FadeFoot5()
    {
        StartCoroutine(Foot5Flow());
    }

    IEnumerator Foot5Flow()
    {
        Foot5.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !Foot5.GetComponent<AudioSource>().isPlaying);
        
        // (player.gameObject.transform.position.x > 1050.0f) && (player.gameObject.transform.position.x < 1220.0f)
        while (player.gameObject.transform.position.x < Foot5.gameObject.transform.position.x - 50)
        {
            m_Animator.GetComponent<Animator>().enabled = true;
            Foot5.gameObject.SetActive(false);
            xMove = 0;
            xMove = +speed;
            player.transform.Translate(new Vector3(xMove, 0, 0));
            yield return null;
        }
        Invoke("F_Out", 2f);
    }

    public void F_Out()
    {
        StartCoroutine(FadeOutFlow());
    }

    IEnumerator FadeOutFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
        SceneManager.LoadScene("Day1_Meeting");
    }
    

    // Update is called once per frame
    void Update()
    {
        m_Animator.GetComponent<Animator>().enabled = false;
    }

}
