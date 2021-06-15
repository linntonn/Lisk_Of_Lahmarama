using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpCounter : MonoBehaviour
{
    private SharedResources resources;

    private TMP_Text expText;

    private void Start()
    {
        resources = FindObjectsOfType<SharedResources>()[0];
        expText = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        expText.text = "EXP: " + resources.current_exp;
    }

}
