using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyCounter : MonoBehaviour
{

    private SharedResources resources;

    private TMP_Text moneyText;

    private void Start()
    {
        resources = FindObjectsOfType<SharedResources>()[0];
        moneyText = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        moneyText.text = "Gold: " + resources.money;
    }

}
