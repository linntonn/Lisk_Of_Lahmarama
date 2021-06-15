using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float spawnLocation;
    public float speed;
    public Vector3 velocity;
    public Vector3 spin;
    public float lifeTimer;
    public GameObject thisProjectile;
    public Rigidbody thisRB;
    public float damage;
    // Start is called before the first frame update
    void Awake()
    {
        velocity = new Vector3(thisProjectile.transform.forward.x * speed, thisProjectile.transform.forward.y * speed, thisProjectile.transform.forward.z * speed);
        thisProjectile.transform.SetParent(null, true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        thisRB.velocity = velocity;
        if (lifeTimer != -1)
        {
            lifeTimer -= Time.deltaTime;
            if (lifeTimer <= 0)
            {
                //Death due to timeout
                Destroy(thisProjectile);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            Destroy(thisProjectile);
        }
        if (other.gameObject.tag == "EnemyHurtbox")
        {
            if (other.gameObject.GetComponent<DamageBoss>() != null)
            {
                other.gameObject.GetComponent<DamageBoss>().HitBoss(damage);
            }
            if (other.gameObject.GetComponent<DamageEnemy>() != null)
            {
                other.gameObject.GetComponent<DamageEnemy>().HitEnemy(damage);
            }
            Destroy(thisProjectile);
        }
    }
}
