using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Components_check : MonoBehaviour
{
    public GameObject components;
    public Button next;
    public Image A1, A2, A3, B1, B2;

    private void Start()
    {
        next.enabled = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            int cnt = transform.childCount; //�ش� ������Ʈ�� �ڽ� ��

            if (cnt == 3)
            {
                for(int j=0; j<2; j++) //��ǰĭ�� �ִ� ������Ʈ ��Ȱ��ȭ
                {
                    if (components.transform.GetChild(j).name.Contains("A_battery"))
                    {
                        A1.GetComponent<Component_movement>().enabled = false;
                    }
                    else if (components.transform.GetChild(j).name.Contains("A_sensor"))
                    {
                        A2.GetComponent<Component_movement>().enabled = false;
                    }
                    else if (components.transform.GetChild(j).name.Contains("A_screw"))
                    {
                        A3.GetComponent<Component_movement>().enabled = false;
                    }
                    else if (components.transform.GetChild(j).name.Contains("B_antenna"))
                    {
                        B1.GetComponent<Component_movement>().enabled = false;
                    }
                    else if (components.transform.GetChild(j).name.Contains("B_woofer"))
                    {
                        B2.GetComponent<Component_movement>().enabled = false;
                    }
                }
                for (int i = 0; i < cnt; i++)
                {
                    //ȸ�� ���� �ʿ����� ���� ��ǰ�� �ִ��� üũ
                    if (!transform.GetChild(i).name.Contains("A_"))
                    {
                        //next.gameObject.SetActive(false);
                        //next.enabled = false;
                        return; 
                    }
                }
                //next.gameObject.SetActive(true);
                next.enabled = true;
            }
            else
            { //2�� ������ ��� ��� ��ǰ �����̵���
                A1.GetComponent<Component_movement>().enabled = true;
                A2.GetComponent<Component_movement>().enabled = true;
                A3.GetComponent<Component_movement>().enabled = true;
                B1.GetComponent<Component_movement>().enabled = true;
                B2.GetComponent<Component_movement>().enabled = true;
                //next.gameObject.SetActive(false);
                next.enabled = false;
            }
        }

    }
}
