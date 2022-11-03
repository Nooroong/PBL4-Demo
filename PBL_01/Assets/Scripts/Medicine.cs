using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Medicine : MonoBehaviour
{
    public Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8;
    public GameObject select1, select2, select3;
    public Button reset;
    public Button make;
    public Button Button;

    int total = 0;

    bool btn1isactive = false;
    bool btn2isactive = false;
    bool btn3isactive = false;
    bool btn4isactive = false;
    bool btn5isactive = false;
    bool btn6isactive = false;
    bool btn7isactive = false;
    bool btn8isactive = false;


    // Start is called before the first frame update
    void Start()
    {
        reset.interactable = false;
        make.interactable = false;

        select1.SetActive(false);
        select2.SetActive(false);
        select3.SetActive(false);

        btn1.GetComponent<Button>().interactable = false;
        btn2.GetComponent<Button>().interactable = false;
        btn3.GetComponent<Button>().interactable = false;
        btn4.GetComponent<Button>().interactable = false;
        btn5.GetComponent<Button>().interactable = false;
        btn6.GetComponent<Button>().interactable = false;
        btn7.GetComponent<Button>().interactable = false;
        btn8.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(total == 1)
        {
            select1.SetActive(true);
        }
        if (total == 2)
        {
            select2.SetActive(true);
        }

        if (total >= 1)
        {
            reset.interactable = true;
        }
        if(total == 3)
        {
            select3.SetActive(true);
            make.interactable = true;
            Btnset();
        }
    }
    public void OnClickButton()
    {
        StartCoroutine(OnClickButton_co(Button));
    }

    public void btn1isClicked()
    {
        btn1isactive = true;
        btn1.interactable = false;
        total++;
        if(total == 1)
        {
            select1.GetComponent<Image>().sprite = Resources.Load("Medicine\\1", typeof(Sprite)) as Sprite;
        }
        if (total == 2)
        {
            select2.GetComponent<Image>().sprite = Resources.Load("Medicine\\1", typeof(Sprite)) as Sprite;
        }
        if (total == 3)
        {
            select3.GetComponent<Image>().sprite = Resources.Load("Medicine\\1", typeof(Sprite)) as Sprite;
        }
    }
    public void btn2isClicked()
    {
        btn2isactive = true;
        btn2.interactable = false;
        total++;
        if (total == 1)
        {
            select1.GetComponent<Image>().sprite = Resources.Load("Medicine\\2", typeof(Sprite)) as Sprite;
        }
        if (total == 2)
        {
            select2.GetComponent<Image>().sprite = Resources.Load("Medicine\\2", typeof(Sprite)) as Sprite;
        }
        if (total == 3)
        {
            select3.GetComponent<Image>().sprite = Resources.Load("Medicine\\2", typeof(Sprite)) as Sprite;
        }
    }
    public void btn3isClicked()
    {
        btn3isactive = true;
        btn3.interactable = false;
        total++;
        if (total == 1)
        {
            select1.GetComponent<Image>().sprite = Resources.Load("Medicine\\3", typeof(Sprite)) as Sprite;
        }
        if (total == 2)
        {
            select2.GetComponent<Image>().sprite = Resources.Load("Medicine\\3", typeof(Sprite)) as Sprite;
        }
        if (total == 3)
        {
            select3.GetComponent<Image>().sprite = Resources.Load("Medicine\\3", typeof(Sprite)) as Sprite;
        }
    }
    public void btn4isClicked()
    {
        btn4isactive = true;
        btn4.interactable = false;
        total++;
        if (total == 1)
        {
            select1.GetComponent<Image>().sprite = Resources.Load("Medicine\\4", typeof(Sprite)) as Sprite;
        }
        if (total == 2)
        {
            select2.GetComponent<Image>().sprite = Resources.Load("Medicine\\4", typeof(Sprite)) as Sprite;
        }
        if (total == 3)
        {
            select3.GetComponent<Image>().sprite = Resources.Load("Medicine\\4", typeof(Sprite)) as Sprite;
        }
    }
    public void btn5isClicked()
    {
        btn5isactive = true;
        btn5.interactable = false;
        total++;
        if (total == 1)
        {
            select1.GetComponent<Image>().sprite = Resources.Load("Medicine\\5", typeof(Sprite)) as Sprite;
        }
        if (total == 2)
        {
            select2.GetComponent<Image>().sprite = Resources.Load("Medicine\\5", typeof(Sprite)) as Sprite;
        }
        if (total == 3)
        {
            select3.GetComponent<Image>().sprite = Resources.Load("Medicine\\5", typeof(Sprite)) as Sprite;
        }
    }
    public void btn6isClicked()
    {
        btn6isactive = true;
        btn6.interactable = false;
        total++;
        if (total == 1)
        {
            select1.GetComponent<Image>().sprite = Resources.Load("Medicine\\6", typeof(Sprite)) as Sprite;
        }
        if (total == 2)
        {
            select2.GetComponent<Image>().sprite = Resources.Load("Medicine\\6", typeof(Sprite)) as Sprite;
        }
        if (total == 3)
        {
            select3.GetComponent<Image>().sprite = Resources.Load("Medicine\\6", typeof(Sprite)) as Sprite;
        }
    }
    public void btn7isClicked()
    {
        btn7isactive = true;
        btn7.interactable = false;
        total++;
        if (total == 1)
        {
            select1.GetComponent<Image>().sprite = Resources.Load("Medicine\\7", typeof(Sprite)) as Sprite;
        }
        if (total == 2)
        {
            select2.GetComponent<Image>().sprite = Resources.Load("Medicine\\7", typeof(Sprite)) as Sprite;
        }
        if (total == 3)
        {
            select3.GetComponent<Image>().sprite = Resources.Load("Medicine\\7", typeof(Sprite)) as Sprite;
        }
    }
    public void btn8isClicked()
    {
        btn8isactive = true;
        btn8.interactable = false;
        total++;
        if (total == 1)
        {
            select1.GetComponent<Image>().sprite = Resources.Load("Medicine\\8", typeof(Sprite)) as Sprite;
        }
        if (total == 2)
        {
            select2.GetComponent<Image>().sprite = Resources.Load("Medicine\\8", typeof(Sprite)) as Sprite;
        }
        if (total == 3)
        {
            select3.GetComponent<Image>().sprite = Resources.Load("Medicine\\8", typeof(Sprite)) as Sprite;
        }
    }

    public void resetBtn()
    {
        total = 0;
        reset.interactable = false;
        make.interactable = false;

        select1.SetActive(false);
        select2.SetActive(false);
        select3.SetActive(false);

        btn1isactive = false;
        btn2isactive = false;
        btn3isactive = false;
        btn4isactive = false;
        btn5isactive = false;
        btn6isactive = false;
        btn7isactive = false;
        btn8isactive = false;

        btn1.interactable = true;
        btn2.interactable = true;
        btn3.interactable = true;
        btn4.interactable = true;
        btn5.interactable = true;
        btn6.interactable = true;
        btn7.interactable = true;
        btn8.interactable = true;

        btn1.enabled = true;
        btn2.enabled = true;
        btn3.enabled = true;
        btn4.enabled = true;
        btn5.enabled = true;
        btn6.enabled = true;
        btn7.enabled = true;
        btn8.enabled = true;
    }
    public void makeBtn()
    {
        StartCoroutine(makeBtn_co(make));
    }

        public void Btnset()
    {
        if (btn1isactive == false){
            btn1.enabled = false;
        }
        if (btn2isactive == false)
        {
            btn2.enabled = false;
        }
        if (btn3isactive == false)
        {
            btn3.enabled = false;
        }
        if (btn4isactive == false)
        {
            btn4.enabled = false;
        }
        if (btn5isactive == false)
        {
            btn5.enabled = false;
        }
        if (btn6isactive == false)
        {
            btn6.enabled = false;
        }
        if (btn7isactive == false)
        {
            btn7.enabled = false;
        }
        if (btn8isactive == false)
        {
            btn8.enabled = false;
        }
    }


    IEnumerator OnClickButton_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        Button.gameObject.SetActive(false);
        btn1.GetComponent<Button>().interactable = true;
        btn2.GetComponent<Button>().interactable = true;
        btn3.GetComponent<Button>().interactable = true;
        btn4.GetComponent<Button>().interactable = true;
        btn5.GetComponent<Button>().interactable = true;
        btn6.GetComponent<Button>().interactable = true;
        btn7.GetComponent<Button>().interactable = true;
        btn8.GetComponent<Button>().interactable = true;
    }

    IEnumerator makeBtn_co(Button obj) {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        SceneManager.LoadScene("Tablet");
    }
}
