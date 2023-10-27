using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapZooming : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] ScrollRect scrollRect;
    float zoomSpeedPinch = 0.001f;
    float zoomSpeedMouseScrollWheel = 0.05f;
    float zoomMin = 1f;
    float zoomMax = 3f;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        Zoom();
    }

    //public void OnDrag(PointerEventData eventData)
    //{
    //    Zoom();
    //    if (Input.touchCount <= 1) scrollRect.OnDrag(eventData);
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    scrollRect.OnEndDrag(eventData);
    //}

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    if (Input.touchCount <= 1) scrollRect.OnBeginDrag(eventData);
    //}

    void Zoom()
    {
        //var contentPosition = rectTransform.anchoredPosition;

        var mouseScrollWheel = Input.mouseScrollDelta.y;
        float scaleChange = 0f;
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = touchDeltaMag - prevTouchDeltaMag;

            scaleChange = deltaMagnitudeDiff * zoomSpeedPinch;
        }

        if (mouseScrollWheel != 0)
        {
            scaleChange = mouseScrollWheel * zoomSpeedMouseScrollWheel;
        }

        if (scaleChange != 0)
        {
            var scaleX = transform.localScale.x;
            scaleX += scaleChange;
            scaleX = Mathf.Clamp(scaleX, zoomMin, zoomMax);
            //var size = rectTransform.rect.size;
            //size.Scale(rectTransform.localScale);
            //var parentRect = ((RectTransform)rectTransform.parent);
            //var parentSize = parentRect.rect.size;
            //parentSize.Scale(parentRect.localScale);

            transform.localScale = new Vector3(scaleX, scaleX, transform.localScale.z);
            //rectTransform.anchoredPosition = contentPosition;
        }
    }
}
