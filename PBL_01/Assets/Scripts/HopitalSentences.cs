using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HopitalSentences : MonoBehaviour
{
    public string[] sentences;

    public void dialog()
    {
        DialogManager.instance.Ondialogue(sentences);
    }
}
