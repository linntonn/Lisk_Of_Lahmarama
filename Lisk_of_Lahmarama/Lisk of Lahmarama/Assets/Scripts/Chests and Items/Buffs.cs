using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public GameObject[] slots;
    
    void Start()
    {
        for(int i =0; i < 8; i++)
        {
            slots[i].SetActive(false);
        }
    }

}
