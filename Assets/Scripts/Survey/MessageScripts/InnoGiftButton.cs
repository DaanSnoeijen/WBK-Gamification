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

    [Header("Should the coins immediately show?")]
    [SerializeField] bool show;

    private void Start()
    {
        if (show)
        {
            CoinsEffect.Play();
            GetComponentInParent<UpdateCoins>().ShowNewCoins(100);
        }
    }

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
