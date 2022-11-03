using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootPrint2 : MonoBehaviour
{

    public Button Foot2;
    int speed = 10;
    float xMove;
    public Image player;

    // Start is called before the first frame update
    void Start()
    {
        player.gameObject.SetActive(true);
    }

    public void FadeFoot2()
    {

        while ((player.gameObject.transform.position.x > 570.0f) && (player.gameObject.transform.position.x < 760.0f))
        {
            gameObject.SetActive(false);
            xMove = 0;
            xMove = +speed * Time.deltaTime;
            player.transform.Translate(new Vector3(xMove, 0, 0));
        }

    }

    // Update is called once per frame
    void Update()
    {
        Foot2.onClick.AddListener(FadeFoot2);
    }
}
