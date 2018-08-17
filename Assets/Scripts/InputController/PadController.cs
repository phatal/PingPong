using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PadController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private List<Pad> padList;
    private float previousPositionX = Mathf.Infinity;
    private Vector2 mousePos;
    private float delta = 0;

    public void Init(List<Pad> padList)
    {
        this.padList = new List<Pad>(padList);
    }

    public void OnDrag(PointerEventData eventData)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (previousPositionX == Mathf.Infinity)
        {
            previousPositionX = mousePos.x;
        }
        else
        {
            delta = mousePos.x - previousPositionX;
            previousPositionX = mousePos.x;
        }
        foreach (var pad in padList)
        {
            pad.transform.position += new Vector3(delta, 0, 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        previousPositionX = Mathf.Infinity;
        delta = 0;
    }

}
