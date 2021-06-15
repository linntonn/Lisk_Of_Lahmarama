using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealingShrineScript : MonoBehaviour
{
    public float price = 10f;
    public int charges = 3;
    public float priceInc = 1.2f;
    public float healing = 25f;
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
        if (charges > 0)
        {
            textpro.text = "Pray for salvation (" + price.ToString() + " CR)";
        }
    }


    void OnTriggerExit()
    {
        textpro.text = "";
    }
    

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player" && charges > 0 && other.gameObject.GetComponent<PlayerInput>() != null && other.gameObject.GetComponent<PlayerInput>().xPress && 
            players.gameObject.GetComponent<SharedResources>().getMoney() >= price)
        {
            other.gameObject.GetComponent<PlayerInput>().hurtPlayer(-healing);
            players.gameObject.GetComponent<SharedResources>().addMoney(-price);
            price *= priceInc;
            charges -= 1;
        }
        
    }

}
