using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    public float money = 0f;

    public void addMoney(float num)
    {
        money += num;
    }
}
