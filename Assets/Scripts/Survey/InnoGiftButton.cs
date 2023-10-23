using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InnoGiftButton : MonoBehaviour
{
    [Header("Click gift interactions")]
    [SerializeField] Animator GiftAnimator;
    [SerializeField] GameObject ClickMessage;
    [SerializeField] Button Button;

    [Header("Click effects")]
    [SerializeField] ParticleSystem CoinsEffect;

    public void PressGift() 
    { 
        GiftAnimator.SetTrigger("Press");
        ClickMessage.SetActive(false);
        Button.enabled = false;
        CoinsEffect.Play();
        GetComponentInParent<UpdateCoins>().ShowNewCoins(15);
        GetComponentInParent<NextMessageLinker>().NextMessage();
    }
}
