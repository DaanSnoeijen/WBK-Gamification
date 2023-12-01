using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeAnnouncement : MonoBehaviour
{
    [Header("Methods to trigger after swiping")]
    [SerializeField] UnityEvent LikeEvent;
    [SerializeField] UnityEvent DislikeEvent;

    [Header("Components for proper raycasting")]
    [SerializeField] GraphicRaycaster GraphicRaycaster;
    [SerializeField] EventSystem EventSystem;

    PointerEventData PointerEventData;
    
    const float MIN_SWIPE_DISTANCE = 0.17f;

    Vector2 startPos;

    bool animDone = false;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            PointerEventData = new PointerEventData(EventSystem);
            PointerEventData.position = Input.GetTouch(0).position;

            List<RaycastResult> results = new List<RaycastResult>();

            GraphicRaycaster.Raycast(PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.name == "Hitbox")
                {
                    Touch t = Input.GetTouch(0);

                    if (t.phase == TouchPhase.Began)
                    {
                        startPos = new Vector2(t.position.x / Screen.width, t.position.y / Screen.width);
                    }
                    else if (t.phase == TouchPhase.Moved && !animDone)
                    {
                        Vector2 endPos = new Vector2(t.position.x / Screen.width, t.position.y / Screen.width);

                        Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

                        if (swipe.magnitude < MIN_SWIPE_DISTANCE) return;

                        if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                        {
                            if (swipe.x > 0) LikeEvent.Invoke();
                            else DislikeEvent.Invoke();

                            animDone = true;
                        }
                    }
                    else if (t.phase == TouchPhase.Ended) animDone = false;
                }
            }
        }
    }
}
