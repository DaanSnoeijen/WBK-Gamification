using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserMapLogic : MonoBehaviour
{
    [Header("Object with point image on map")]
    [SerializeField] RectTransform Pointer;

    public void SetPointer()
    {
        Vector2 position = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        position.y += 550;
        position.x -= 680;
        Pointer.anchoredPosition = position;

        GetComponentInParent<NextMessageLinker>().NextMessage();
    }
}
