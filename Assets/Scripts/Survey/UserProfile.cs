using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfile : MonoBehaviour
{
    float prizePrice = 500;

    public float coins { get; private set; }

    public void SetCoins(int setAmount) { coins = setAmount; }

    public float ReturnPrizePercent() { return coins / prizePrice * 100f; }
}
