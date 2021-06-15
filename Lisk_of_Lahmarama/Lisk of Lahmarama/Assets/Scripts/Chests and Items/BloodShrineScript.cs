using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BloodShrineScript : MonoBehaviour
{
    public float damagePercent = 0.5f;
    public TMP_Text textpro;

    SharedResources players;

    // Start is called before the first frame update
    void Start()
    {
        players = FindObjectsOfType<SharedResources>()[0];
        textpro.text = "";
    }

    
    void OnTriggerEnter()
    {
        textpro.text = "Offer your blood (" + (damagePercent*100).ToString() + "% Health)";
    }


    void OnTriggerExit()
    {
        textpro.text = "";
    }
 

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player" && other.gameObject.GetComponent<PlayerInput>() != null && other.gameObject.GetComponent<PlayerInput>().xPress)
        {
            float money = other.gameObject.GetComponent<PlayerInput>().hurtPlayerPercentage(damagePercent);
            players.gameObject.GetComponent<SharedResources>().addMoney(money);
        }
        
    }

}
