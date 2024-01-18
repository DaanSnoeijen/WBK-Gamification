using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionPanelLogic : MonoBehaviour
{
    [Header("Anmators")]
    [SerializeField] Animator PositionSelectionAnimator;
    [SerializeField] Animator DescriptionAnimator;

    [Header("Other")]
    [SerializeField] Button MapButton;
    [SerializeField] TMP_InputField InputField;

    public void DescriptionButton() { StartCoroutine(IDescriptionNext()); }

    IEnumerator IDescriptionNext()
    {
        MapButton.interactable = true;

        DescriptionAnimator.SetTrigger("Hide");
        PositionSelectionAnimator.SetTrigger("Show");

        yield return new WaitForSeconds(1f);

        InputField.text = "";
    }
}
