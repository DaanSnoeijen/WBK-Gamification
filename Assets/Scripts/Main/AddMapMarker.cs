using UnityEngine;
using UnityEngine.UI;

public class AddMapMarker : MonoBehaviour
{
    [Header("New marker attributes")]
    [SerializeField] GameObject NewMarker;
    [SerializeField] Transform ParentObject;
    [SerializeField] Button MapButton;

    bool canPlace;

    public void SetCanPlace(bool set) { canPlace = set; }

    public void PlaceMarker()
    {
        if (canPlace)
        {
            MapButton.interactable = false;

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
