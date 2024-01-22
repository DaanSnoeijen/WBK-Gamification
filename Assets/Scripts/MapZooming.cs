using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MapZooming : MonoBehaviour
{
    [Header("Scroll view to zoom")]
    [SerializeField] ScrollRect scrollRect;

    [Header("Marker compilers if necessary")]
    [SerializeField] List<MarkerCompiler> _MarkerCompilers;

    float zoomSpeedPinch = 0.005f;
    float zoomSpeedMouseScrollWheel = 0.05f;
    float zoomMin = 1f;
    float zoomMax = 3f;

    float markerZoom = 2.5f;

    private void LateUpdate()
    {
        Zoom();
    }
    public void SetMarkerZoom() { transform.localScale = new Vector3(markerZoom, markerZoom, transform.localScale.z); }

    void Zoom()
    {
        var mouseScrollWheel = Input.mouseScrollDelta.y;
        float scaleChange = 0f;
        if (Input.touchCount == 2)
        {
            scrollRect.horizontal = false;
            scrollRect.vertical = false;

            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = touchDeltaMag - prevTouchDeltaMag;

            scaleChange = deltaMagnitudeDiff * zoomSpeedPinch;
        }
        else
        {
            scrollRect.horizontal = true;
            scrollRect.vertical = true;
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

            transform.localScale = new Vector3(scaleX, scaleX, transform.localScale.z);
            CheckZoom(scaleX);
        }
    }

    void CheckZoom(float scale)
    {
        if (_MarkerCompilers.Count == 0) return;

        if (scale > 2f) foreach (MarkerCompiler item in _MarkerCompilers) item.SwitchMarkerView(true);
        else foreach (MarkerCompiler item in _MarkerCompilers) item.SwitchMarkerView(false);
    }
}
