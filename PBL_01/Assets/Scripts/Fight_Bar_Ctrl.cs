using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight_Bar_Ctrl : MonoBehaviour
{
    public Button btn;
    public Image Bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tap_char()
    {
        Bar.GetComponent<Image>().fillAmount += 0.05f;
    }
}
