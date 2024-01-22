using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    [SerializeField] RectTransform RectPos;
    [SerializeField] MapZooming Zooming;

    Vector3 startPos;

    private void Start()
    {
        startPos = RectPos.position;
        startPos.x *= 2.7f;
        startPos.y *= 1.9f;
    }

    public void FocusOn(RectTransform focusPos)
    {
        Zooming.SetMarkerZoom();

        Vector2 newPos = focusPos.anchoredPosition;
        newPos.x /= 1.5f;
        newPos.y /= 1.5f;
        newPos.x += 665f;
        newPos.y -= 100f;

        RectPos.anchoredPosition = newPos;
    }
}
