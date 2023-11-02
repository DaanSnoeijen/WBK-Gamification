using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CircleSliderButton : Button, IDragHandler
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        GetComponentInParent<NormalSliderLogic>().ButtonUp();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        GetComponentInParent<NormalSliderLogic>().ButtonDown();
    }

    public void OnDrag(PointerEventData eventData) { }
}
