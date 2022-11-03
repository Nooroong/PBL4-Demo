using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Component_movement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 defaultPosition; //드롭 후 원위치로 보내기 위한 변수
    public float smoothTime = 0.0005f;

    //터치 영역 관련 코드1. 이미지들을 패킹하면 이 기능을 쓸 수 없다...
    public float AlphaThreshold = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        //터치 영역 관련 코드2
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        //드래그를 시작할 때의 마우스 좌표를 저장
        Vector2 mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldObjectPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);
        defaultPosition = worldObjectPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //드래그가 이뤄지는 순간의 마우스 포지션을 받아 오브젝트가 포인터를 따라가게 함.
        Vector2 mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldObjectPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);

        this.transform.position = worldObjectPosition;
        //기억 조각이 맨 앞에 위치하도록 임시로 부모 변경
        transform.SetParent(GameObject.Find("empty").transform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //카메라에서 마우스 위치로 Ray를 쏴서 '콜라이더'와 맞았는지 판별
        //감지를 원하는 오브젝트에 콜라이더를 추가해야한다.
        Vector2 mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldObjectPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);

        Vector2 wp = worldObjectPosition; //버튼을 뗐을 때 좌표를 가져옴
        Ray2D ray = new Ray2D(wp, Vector2.zero); //원점에서 마우스 좌표 방향으로 Ray를 쏨
        float distance = Mathf.Infinity; //Ray 내에서 감지할 최대 거리

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance);

        if (hit)
        {
            StartCoroutine(UntilPlayback(this.GetComponent<Image>()));
            this.transform.position = wp;
            //부모를 변경. hit.collider.name: ray 맞은 오브젝트 이름인듯?
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
