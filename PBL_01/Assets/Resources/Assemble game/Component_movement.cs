using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Component_movement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 defaultPosition; //��� �� ����ġ�� ������ ���� ����
    public float smoothTime = 0.0005f;

    //��ġ ���� ���� �ڵ�1. �̹������� ��ŷ�ϸ� �� ����� �� �� ����...
    public float AlphaThreshold = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        //��ġ ���� ���� �ڵ�2
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        //�巡�׸� ������ ���� ���콺 ��ǥ�� ����
        Vector2 mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldObjectPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);
        defaultPosition = worldObjectPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //�巡�װ� �̷����� ������ ���콺 �������� �޾� ������Ʈ�� �����͸� ���󰡰� ��.
        Vector2 mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldObjectPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);

        this.transform.position = worldObjectPosition;
        //��� ������ �� �տ� ��ġ�ϵ��� �ӽ÷� �θ� ����
        transform.SetParent(GameObject.Find("empty").transform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //ī�޶󿡼� ���콺 ��ġ�� Ray�� ���� '�ݶ��̴�'�� �¾Ҵ��� �Ǻ�
        //������ ���ϴ� ������Ʈ�� �ݶ��̴��� �߰��ؾ��Ѵ�.
        Vector2 mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldObjectPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);

        Vector2 wp = worldObjectPosition; //��ư�� ���� �� ��ǥ�� ������
        Ray2D ray = new Ray2D(wp, Vector2.zero); //�������� ���콺 ��ǥ �������� Ray�� ��
        float distance = Mathf.Infinity; //Ray ������ ������ �ִ� �Ÿ�

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance);

        if (hit)
        {
            StartCoroutine(UntilPlayback(this.GetComponent<Image>()));
            this.transform.position = wp;
            //�θ� ����. hit.collider.name: ray ���� ������Ʈ �̸��ε�?
            transform.SetParent(GameObject.Find(hit.collider.name).transform);
        }
        else
        {
            this.transform.position = defaultPosition;
        }
    }

        
    IEnumerator UntilPlayback(Image obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
    }
}
