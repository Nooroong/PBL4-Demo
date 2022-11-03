using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickAndHide : MonoBehaviour
{
    public GameObject obj;

    public void Clicked()
    {
        Invoke("Hide", 0.5f);
        
    }

    private void Hide()
    {
        obj.SetActive(false);
    }
}
