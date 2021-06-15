using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnPickupDelay : MonoBehaviour
{
    public Collider itemHitbox;
    public float waitTime;
    public float waitCounter;
    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitTime;
        itemHitbox.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (waitCounter <= 0)
        {
            if (!itemHitbox.enabled)
            {
                itemHitbox.enabled = true;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
        }
    }
}
