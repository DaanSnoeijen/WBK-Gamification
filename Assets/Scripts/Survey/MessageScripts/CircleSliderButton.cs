using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CircleSliderButton : Button, IDragHandler
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        GetComponentInParent<CircleSliderLogic>().ButtonUp();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        GetComponentInParent<CircleSliderLogic>().ButtonDown();
    }

    public void OnDrag(PointerEventData eventData) { }
}
