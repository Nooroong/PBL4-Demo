using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class machine : MonoBehaviour
{

    int speed = 80;
    float yMove;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yMove = 0;
        yMove = -speed * Time.deltaTime;
        this.transform.Translate(new Vector3(0, yMove, 0));

    }
}
