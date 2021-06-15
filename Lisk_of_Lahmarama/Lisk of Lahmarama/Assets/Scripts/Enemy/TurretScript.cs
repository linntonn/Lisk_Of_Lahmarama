using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public GameObject turret;
    public GameObject bullet;
    public GameObject bulletSpawn;
    public float rotationSpeed = 5.0f;
    public float aggroRange = 10.0f;
    public float rof = 1;

    public float fireTimer = 2f;
    public float fireCounter;
    Vector3 targetLoc;

    GameObject[] targets;
    GameObject target1;
    GameObject target2;

    // Start is called before the first frame update
    void Start()
    {
        fireCounter = fireTimer;
        targets = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].GetComponent<PlayerInput>() != null)
            {
                if (target1 == null)
                    target1 = targets[i];
                else
                    target2 = targets[i];
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fireCounter -= Time.deltaTime;
        if(Vector3.Distance(transform.position, target1.transform.position) < Vector3.Distance(transform.position, target2.transform.position))
        {
            targetLoc = target1.transform.position;
        }
        else
        {
            targetLoc = target2.transform.position;
        }

        if (Vector3.Distance(transform.position, targetLoc) < aggroRange)
        {
            Vector3 diff = targetLoc - turret.transform.position;
            float sign = (targetLoc.y < turret.transform.position.y) ? -1.0f : 1.0f;
            float angle = Vector3.Angle(Vector3.right, diff) * sign;

            turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed * Time.deltaTime);

            if (fireCounter <= 0)
            {
                Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                fireCounter = fireTimer;
            }

        }
        else
        {
            turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, Quaternion.AngleAxis(-90.0f, Vector3.forward), rotationSpeed * Time.deltaTime);
        }
    }
}
