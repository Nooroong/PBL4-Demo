using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fightgame_Direct : MonoBehaviour
{
    public GameObject game_ctrl;
    public Button start, faceBTN;

    void Awake()
    {
        game_ctrl.GetComponent<Fight_game>().enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        faceBTN.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void game_Start()
    {
        game_ctrl.GetComponent<Fight_game>().enabled = true;
        faceBTN.interactable = true;
        start.gameObject.SetActive(false);
    }

}
