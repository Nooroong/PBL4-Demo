using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Components_check2 : MonoBehaviour
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
            int cnt = transform.childCount; //해당 오브젝트의 자식 수

            if (cnt == 3)
            {
                for (int j = 0; j < 2; j++) //부품칸에 있는 오브젝트 비활성화
                {
                    if (components.transform.GetChild(j).name.Contains("A_alloy"))
                    {
                        A1.GetComponent<Component_movement>().enabled = false;
                    }
                    else if (components.transform.GetChild(j).name.Contains("A_ducktape"))
                    {
                        A2.GetComponent<Component_movement>().enabled = false;
                    }
                    else if (components.transform.GetChild(j).name.Contains("A_glass"))
                    {
                        A3.GetComponent<Component_movement>().enabled = false;
                    }
                    else if (components.transform.GetChild(j).name.Contains("B_gluegun"))
                    {
                        B1.GetComponent<Component_movement>().enabled = false;
                    }
                    else if (components.transform.GetChild(j).name.Contains("B_solderwire"))
                    {
                        B2.GetComponent<Component_movement>().enabled = false;
                    }
                }
                for (int i = 0; i < cnt; i++)
                {
                    //회로 위에 필요하지 않은 부품이 있는지 체크
                    if (!transform.GetChild(i).name.Contains("A_"))
                    {
                        //next.gameObject.SetActive(false);
                        return;
                    }
                }
                //next.gameObject.SetActive(true);
                next.enabled = true;
            }
            else
            { //2개 이하인 경우 모든 부품 움직이도록
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
