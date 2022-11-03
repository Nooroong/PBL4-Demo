using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fightgame_black : MonoBehaviour
{
    public Image image;
    float time = 0f;
    float F_time = 2f;

    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeOut()
    {
        time = 0f;
        StartCoroutine(FadeOutFlow());
    }
    IEnumerator FadeOutFlow()
    {

        image.gameObject.SetActive(true);
        Color alpha = image.color;

        yield return null;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            image.color = alpha;
            yield return null;
        }
        time = 0f;
        yield return null;
    }
}
