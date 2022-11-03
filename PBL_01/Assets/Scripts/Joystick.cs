using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//https://unitybeginner.tistory.com/30

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
    public RectTransform innerPad; //안쪽 원
    public RectTransform outerPad; //바깥 원

    private float deadZone = 0; //안쪽 원의 이동 범위?
    private float handleRange = 1;
    private Vector3 input = Vector3.zero;
    private Canvas canvas;

    //일단 둘 다 0f로 설정하는듯?
    public float Horizontal { get { return input.x; } }
    public float Vertical { get { return input.y; } }

    void Start() {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        outerPad = gameObject.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData) {
        //anchors 설정: outer pad는 bottom-left, inner pad는 middle-center (이유는 몰루)
        Vector2 radius = outerPad.sizeDelta / 2;
        input = (eventData.position - outerPad.anchoredPosition) / (radius * canvas.scaleFactor); //(터치 좌표-)
        HandleInput(input.magnitude, input.normalized); //magnitude: length of vector, normalized: 벡터 정규화
        innerPad.anchoredPosition = input * radius * handleRange;
    }

    private void HandleInput(float magnitude, Vector2 normalised) {
        if (magnitude > deadZone) {
            if (magnitude > 1) {
                input = normalised;
            }
        } else {
            input = Vector2.zero;
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        input = Vector2.zero;
        innerPad.anchoredPosition = Vector2.zero; //안쪽 원의 위치를 제자리로
    }
}
