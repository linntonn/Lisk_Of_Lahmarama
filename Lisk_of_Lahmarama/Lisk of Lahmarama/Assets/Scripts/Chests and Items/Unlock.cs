using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Unlock : MonoBehaviour
{

    public BoxCollider doorTrigger;
    public int keysRequired = 1;
    public TMP_Text textpro;

    SharedResources players;

    void Start()
    {
        textpro.text = "";
        players = FindObjectsOfType<SharedResources>()[0];
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && players.gameObject.GetComponent<SharedResources>() != null)
        {
            textpro.text = "Unlock this door (" + keysRequired.ToString() + " Key)";

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && players.gameObject.GetComponent<SharedResources>() != null)
        {
            textpro.text = "Unlock this door (" + keysRequired.ToString() + " Key)";

        }
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && players.gameObject.GetComponent<SharedResources>() != null && other.GetComponent<PlayerInput>() != null && other.gameObject.GetComponent<PlayerInput>().xPress
            && players.gameObject.GetComponent<SharedResources>().current_keys >= keysRequired)
        {
            players.gameObject.GetComponent<SharedResources>().addKeys(-keysRequired);
            Destroy(gameObject);
        }
    }
    
}
