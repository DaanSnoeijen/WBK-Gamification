using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class AddMapMarker : MonoBehaviour
{
    [Header("New marker attributes")]
    [SerializeField] RectTransform NewMarker;
    [SerializeField] Animator MarkerAnimator;
    [SerializeField] ParticleSystem SmokeEffect;

    bool canPlace;

    public void SetCanPlace(bool set) { canPlace = set; }

    public void PlaceMarker()
    {
        if (canPlace)
        {
            Vector2 position = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            position.y += 1065;
            position.x -= 1490;
            NewMarker.anchoredPosition = position;

            MarkerAnimator.SetTrigger("Land");
            SmokeEffect.Play();
        }
    }
}
