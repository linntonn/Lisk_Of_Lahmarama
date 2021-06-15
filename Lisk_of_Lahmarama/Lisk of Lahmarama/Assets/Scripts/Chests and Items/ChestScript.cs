using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ChestScript : MonoBehaviour
{
    public GameObject item; //remove public later
    public GameObject closeLid;
    public GameObject openLid;
    public GameObject itemSpawn;
    public TMP_Text textpro;
    public float price = 10f;

    bool opened = false;
    SharedResources players;

    // Start is called before the first frame update
    void Start()
    {
        players = FindObjectsOfType<SharedResources>()[0];
        textpro.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (!opened && other.tag == "Player" && other.gameObject.GetComponent<PlayerInput>() != null)
        {
            textpro.text = "Press ATK To Open (" + price.ToString() + " Gold)";
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && other.gameObject.GetComponent<PlayerInput>() != null)
        {
            textpro.text = "";
        }
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && other.gameObject.GetComponent<PlayerInput>() != null && other.gameObject.GetComponent<PlayerInput>().xPress && !opened &&
            players.gameObject.GetComponent<SharedResources>().getMoney() >= price)
        {
            opened = true;
            closeLid.SetActive(false);
            openLid.SetActive(true);

            Instantiate(item, itemSpawn.transform.position, itemSpawn.transform.rotation);
            players.gameObject.GetComponent<SharedResources>().addMoney(-price);
        }
    }
    
}
