using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlatform : MonoBehaviour
{
    public float lifeTimer = 2.5f;
    public float lifeCounter;
    public float respawnTimer = 5f;
    public float respawnCounter = 5f;
    public bool fragile;
    public Renderer bottom;
    public Renderer top;
    public Collider collision;
    // Start is called before the first frame update
    void Start()
    {
        lifeCounter = lifeTimer;
        respawnCounter = respawnTimer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fragile)
        {
            lifeCounter -= Time.deltaTime;
            if (lifeCounter < lifeTimer / 2)
            {
                bottom.enabled = false;
            }
            if (lifeCounter <= 0)
            {
                top.enabled = false;
                collision.enabled = false;
                respawnCounter -= Time.deltaTime;
                if (respawnCounter <= 0)
                {
                    fragile = false;
                    top.enabled = true;
                    collision.enabled = true;
                    bottom.enabled = true;
                    respawnCounter = respawnTimer;
                    lifeCounter = lifeTimer;
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerInput>() != null)
        {
            if (other.gameObject.GetComponent<PlayerInput>().onGround == true)
            {
                fragile = true;
            }
        }
    }
}