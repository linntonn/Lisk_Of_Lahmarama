using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] full;
    public GameObject[] slots;

    public GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        slots = new GameObject[2];
        for (int i = 0; i < 2; ++i)
        {
            slots[i] = inventory.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {



    }
    public void pickUpWeapon(GameObject weapon)
    {
        if (slots[0] != null)
        {
            slots[0].transform.parent = null;
            slots[0].transform.position = weapon.transform.position;
            slots[0].transform.rotation = weapon.transform.rotation;
        }

        slots[0] = weapon;
    }

}
