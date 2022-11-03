using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_t : MonoBehaviour
{
    IEnumerator MouseDrag()
    {
        while (Input.GetMouseButton(0))
        {
            Vector2 mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldObjectPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);
            this.transform.position = worldObjectPosition;
            yield return null;
        }
    }
    private void Update()
    {
        StartCoroutine(MouseDrag());
    }
}
