using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    public int numSpawns;
    public List<GameObject> enemies;

    List<GameObject> spawnList = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Transform spawn in transform)
        {
            spawnList.Add(spawn.gameObject);
        }

        List<int> spawns = nChoose(numSpawns, spawnList.Count);

        foreach (int index in spawns)
        {
            GameObject chestInstance = Instantiate(enemies[Random.Range(0, enemies.Count)], spawnList[index].transform.position, spawnList[index].transform.rotation) as GameObject;
            spawnList[index].GetComponent<SpawnPoint>().enemySpawned = chestInstance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<int> nChoose(int numChests, int numSpawns)
    {
        List<int> spawns = new List<int>();
        for (int i = 0; i < numSpawns; i++)
        {
            float chance = (float)numChests / (float)(numSpawns - i);
            float prob = Random.value;
            Debug.Log(chance.ToString());
            Debug.Log(prob.ToString());
            if (prob < chance)
            {
                spawns.Add(i);
                numChests -= 1;
            }
        }
        return spawns;
    }
}
