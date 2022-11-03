using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant1 : MonoBehaviour
{
    public Button plant1;
    public Text text;
    int speed = 100;
    float yMove;
    Vector3 text_pos;

    void Start()
    {
        text.gameObject.SetActive(false);

        plant1.onClick.AddListener(ShowHeart);

        text_pos = text.transform.position;

    }
    void Update()
    {

    }
    void ShowHeart()
    {
        text.gameObject.SetActive(true);
        text.transform.position = text_pos;
        StartCoroutine(FadeText());
    }

    public IEnumerator FadeText()
    {
        yMove = 0;
       
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 1.0f));
            yMove = +speed * Time.deltaTime;
            text.transform.Translate(new Vector3(0, yMove, 0));
            
            if (text.gameObject.transform.position.y > 1000.0f)
            {
                break;
            }
            yield return null;

        }
        StartCoroutine(FadeTextToZero());

    }

    public IEnumerator FadeTextToZero()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }

    }



}
