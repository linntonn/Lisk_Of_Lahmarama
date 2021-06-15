using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeathScript : MonoBehaviour
{
    public GameObject thingToKill;
    public float lifeTimer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer < 0)
        {
            Destroy(thingToKill);
        }
    }
}
