using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemySpawned;

    public bool destroyed = false;

    public void resetPosition()
    {
        if (!destroyed)
        {
            if (enemySpawned.GetComponent<CharacterController>() != null)
            {
                enemySpawned.GetComponent<CharacterController>().enabled = false;
            }
            enemySpawned.transform.position = transform.position;
            if (enemySpawned.GetComponent<CharacterController>() != null)
            {
                enemySpawned.GetComponent<CharacterController>().enabled = true;
            }
        }
            
    }

    public void despawn()
    {
        if (!destroyed)
            enemySpawned.SetActive(false);
    }

    public void respawn()
    {
        if (!destroyed)
        {
            enemySpawned.SetActive(true);
            resetPosition();
        }
    }

    public void Update()
    {
        if (enemySpawned == null)
        {
            destroyed = true;
        }
    }
}
