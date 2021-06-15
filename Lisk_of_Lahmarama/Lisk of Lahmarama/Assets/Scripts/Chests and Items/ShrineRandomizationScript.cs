using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineRandomizationScript : MonoBehaviour
{
    public int type = 0;

    public int numShrines = 1;
    public GameObject shrineObject;

    public float minPrice = 5f;
    public float maxPrice = 15f;
    public float healing = 25f;

    public float damagePercent = 0.5f;

    List<GameObject> spawnList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform spawn in transform)
        {
            spawnList.Add(spawn.gameObject);
        }

        List<int> spawns = nChoose(numShrines, spawnList.Count);

        foreach (int index in spawns)
        {
            GameObject shrineInstance = Instantiate(shrineObject, spawnList[index].transform.position, spawnList[index].transform.rotation) as GameObject;
            if(type == 0) //HEALING
            {
                shrineInstance.GetComponent<HealingShrineScript>().price = Mathf.Round(Random.Range(minPrice, maxPrice));
                shrineInstance.GetComponent<HealingShrineScript>().healing = healing;
            }
            else if (type == 1) //BLOOD
            {
                shrineInstance.GetComponent<BloodShrineScript>().damagePercent = damagePercent;
            }
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
