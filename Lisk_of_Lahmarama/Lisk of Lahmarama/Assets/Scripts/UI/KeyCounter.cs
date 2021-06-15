using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyCounter : MonoBehaviour
{
    private SharedResources resources;

    private TMP_Text keyText;

    private void Start()
    {
        resources = FindObjectsOfType<SharedResources>()[0];
        keyText = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        keyText.text = "Keys: " + resources.current_keys;
    }

}
