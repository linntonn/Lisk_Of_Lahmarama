using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestRandomizationScript : MonoBehaviour
{
    public int numChests;
    public GameObject chestObject;
    public List<GameObject> lootTable;
    public float minPrice = 5f;
    public float maxPrice = 15f;

    List<GameObject> spawnList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform spawn in transform)
        {
            spawnList.Add(spawn.gameObject);
        }

        List<int> spawns = nChoose(numChests, spawnList.Count);

        foreach (int index in spawns)
        {
            GameObject chestInstance = Instantiate(chestObject, spawnList[index].transform.position, spawnList[index].transform.rotation) as GameObject;
            chestInstance.GetComponent<ChestScript>().item = lootTable[Random.Range(0, lootTable.Count)];
            chestInstance.GetComponent<ChestScript>().price = Mathf.Round(Random.Range(minPrice, maxPrice));
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
            if (prob < chance)
            {
                spawns.Add(i);
                numChests -= 1;
            }
        }
        return spawns;
    }
}

