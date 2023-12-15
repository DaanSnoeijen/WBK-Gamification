using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class AddMapMarker : MonoBehaviour
{
    [Header("New marker attributes")]
    [SerializeField] GameObject NewMarker;
    [SerializeField] Transform ParentObject;

    bool canPlace;

    public void SetCanPlace(bool set) { canPlace = set; }

    public void PlaceMarker()
    {
        if (canPlace)
        {
            Vector2 newPosition = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            newPosition.y += 1065;
            newPosition.x -= 1490;

            GameObject newMarker = Instantiate(NewMarker, ParentObject);
            newMarker.GetComponent<RectTransform>().anchoredPosition = newPosition;
            newMarker.GetComponentInChildren<Animator>().SetTrigger("Land");
            newMarker.GetComponentInChildren<ParticleSystem>().Play();
        }
    }
}
