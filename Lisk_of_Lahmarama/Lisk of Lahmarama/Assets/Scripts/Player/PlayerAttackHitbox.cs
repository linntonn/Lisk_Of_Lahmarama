using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    public Collider hitbox;
    public GameObject Weapon;
    public float weaponDamage;
    // Start is called before the first frame update
    void Start()
    {
        hitbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableHitbox()//GameObject WeaponData)
    {
        hitbox.enabled = true;
        //Weapon = WeaponData;
    }

    public void DisableHitbox()
    {
        hitbox.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyHurtbox")
        {
            if (other.gameObject.GetComponent<DamageBoss>() != null)
            {
                other.gameObject.GetComponent<DamageBoss>().HitBoss(weaponDamage);
                hitbox.enabled = false;
            }
            if (other.gameObject.GetComponent<DamageEnemy>() != null)
            {
                other.gameObject.GetComponent<DamageEnemy>().HitEnemy(weaponDamage);

                //Remove collision for ONLY THE TARGET BEING HIT
                hitbox.enabled = false;
            }
        }
    }
}
