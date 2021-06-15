using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20.0f;
    public float damage = 5.0f;
    public Rigidbody rb;
    public float deathTimer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    void FixedUpdate()
    {
        deathTimer -= Time.deltaTime;
        if (deathTimer < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.GetCompnent<PlayerInput>().TakeDamage(damage);
        if (other.gameObject.tag == "Player" | other.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);
        }
    }


}
