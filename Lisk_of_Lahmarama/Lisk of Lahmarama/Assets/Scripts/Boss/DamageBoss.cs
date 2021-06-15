using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoss : MonoBehaviour
{
    public float damageMultiplier = 1;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitBoss(float damage)
    {
        boss.GetComponent<EarthDragonAI>().HurtBoss(damage * damageMultiplier);
    }
}
