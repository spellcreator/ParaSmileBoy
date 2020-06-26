using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    private bool dragging;
    [SerializeField] private Image outline;
    private float xBound;
    private float yBound;
    Vector3 maxPos;

    [SerializeField] private Transform xMax;
    [SerializeField] private Transform yMax;

    public Vector3 GetAxis
    {
        get; private set;
    }

    private void Start()
    {
        xBound = xMax.localPosition.x;
        yBound = yMax.localPosition.y;
        maxPos = new Vector3(xBound, yBound, 0);
    }


    public void OnDrag(PointerEventData eventData)
    {
        dragging = true;
        Vector3 pos = this.transform.localPosition + (Vector3)eventData.delta / transform.localScale.x ;
        Vector3 newPos = new Vector3(Mathf.Clamp(pos.x, -maxPos.x, maxPos.x), Mathf.Clamp(pos.y, -maxPos.y, maxPos.y), 0);
        transform.localPosition = newPos;

        float xAxis = Mathf.InverseLerp(-maxPos.x, maxPos.x, newPos.x ) * 2 - 1;
        float yAxis = Mathf.InverseLerp(-maxPos.y, maxPos.y, newPos.y) * 2 - 1;

        GetAxis = new Vector3(xAxis, yAxis, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
        GetAxis = Vector3.zero;
        transform.localPosition = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Нужно, потому что без него OnPointerUp неработает :(
    }
}
