using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float atk;

    // Start is called before the first frame update
    void Start()
    {

    }

    public float getWepInfo()
    {
        return atk;
    }

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<Inventory>().pickUpWeapon(gameObject);
        if (other.tag == "Player" && other.gameObject.GetComponent<PlayerInput>() != null && transform.parent == null && other.gameObject.GetComponent<PlayerInput>().xPress)
        {
            //pickup this weapon and drop the other
        }
    }
}
