using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public float damageMultiplier = 1;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HitEnemy(float damage)
    {
        enemy.GetComponent<EnemyManager>().HurtEnemy(damage * damageMultiplier);
    }
}
