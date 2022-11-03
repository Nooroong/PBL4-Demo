using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//https://unitybeginner.tistory.com/30

public class Joystick_shooting : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform innerPad; //���� ��
    public RectTransform outerPad; //�ٱ� ��

    private float deadZone = 0; //���� ���� �̵� ����?
    private float handleRange = 1;
    private Vector3 input = Vector3.zero;
    private Canvas canvas;

    //�ϴ� �� �� 0f�� �����ϴµ�?
    public float Horizontal { get { return input.x; } }
    public float Vertical { get { return input.y; } }

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        outerPad = gameObject.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //anchors ����: outer pad�� bottom-left, inner pad�� middle-center (������ ����)
        Vector2 radius = outerPad.sizeDelta / 2;
        Vector2 event_pos = Camera.main.ScreenToWorldPoint(eventData.position);
        event_pos.x -= 1.8f;
        event_pos.y -= 1.9f;
        Vector2 outer_pos = outerPad.position;
        Vector2 input_pos = (event_pos - outer_pos) * 100;
        input = input_pos / (radius * canvas.scaleFactor); //(��ġ ��ǥ-)
        HandleInput(input.magnitude, input.normalized); //magnitude: length of vector, normalized: ���� ����ȭ
        innerPad.anchoredPosition = input * radius *  handleRange;
    }

    private void HandleInput(float magnitude, Vector2 normalised)
    {
        if (magnitude > deadZone)
        {
            if (magnitude > 1)
            {
                input = normalised;
            }
        }
        else
        {
            input = Vector2.zero;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        innerPad.anchoredPosition = Vector2.zero; //���� ���� ��ġ�� ���ڸ���
    }
    public void timeIsZero()
    {
        input = Vector2.zero;
        innerPad.anchoredPosition = Vector2.zero; //���� ���� ��ġ�� ���ڸ���
    }
}

