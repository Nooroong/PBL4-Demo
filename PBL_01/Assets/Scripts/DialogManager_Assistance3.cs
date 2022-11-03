using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DialogManager_Assistance3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Text m_TypingText;
    public string m_Message;
    public float m_Speed = 0.1f;
    public Image Panel;

    // Start is called before the first frame update 
    void Start()
    {
        m_Message = @"도와주세요..";

        StartCoroutine(Typing(m_TypingText, m_Message, m_Speed));

        Invoke("Hide", 3f);
    }
    
    void Hide()
    {
        Panel.gameObject.SetActive(false);

    }

    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
    }
}
