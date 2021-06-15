using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InFrontOfEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyManager enemy;
    public int commandType; //1 is for cliff, 2 is for jump
    public bool isEmpty;

    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (isEmpty && commandType == 1)
        {
            enemy.EnemyAICommand = commandType;
        }
        isEmpty = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Terrain" && commandType == 2)
        {
            enemy.EnemyAICommand = commandType;
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Terrain" && commandType == 2)
        {
            enemy.EnemyAICommand = 0;
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (commandType == 1 && other.gameObject.tag == "Terrain")
        {
            isEmpty = false;
        }
    }
}
