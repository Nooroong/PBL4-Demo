using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_test : MonoBehaviour
{

    public float speed = 0.1f;
    public Text text;
    public Button btn;
    float yMove;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(ShowHeart);
        text.gameObject.SetActive(false);
        Vector3 v = transform.position;
        v.y = 400;
        transform.position = v;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ShowHeart()
    {
        text.gameObject.SetActive(true);
        StartCoroutine(FadeText());
    }
/*
    public IEnumerator FadeText()
    {
        yMove = 0;
        while (text.gameObject.transform.position.y < 550.0f)
        {
            yMove = +speed * Time.deltaTime;
            text.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 1.0f));
            yield return null;
        }
    }
    */

    public IEnumerator FadeText()
    {
      
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {

            transform.Translate(0, speed, 0);

            if (transform.position.y > 600)
            {
                text.gameObject.SetActive(false);
                Vector3 v = transform.position;
                v.y = 400;
                transform.position = v;
            }
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 1.0f));
            yield return null;
        }
    }
    
}
