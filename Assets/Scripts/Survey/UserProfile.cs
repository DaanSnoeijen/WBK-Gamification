using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfile : MonoBehaviour
{
    float prizePrice = 500;

    public float coins { get; private set; }

    public void AddCoins(int addAmount) { coins += addAmount; }

    public float ReturnPrizePercent() { return coins / prizePrice * 100f; }
}
