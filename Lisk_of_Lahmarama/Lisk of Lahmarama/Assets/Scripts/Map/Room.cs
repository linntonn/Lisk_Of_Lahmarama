using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public bool scrollHorizontal;

    public bool scrollVertical;

    public List<Transform> cameraLimits;

    public List<SpawnPoint> enemySpawns;

    public void Start()
    {
        foreach (SpawnPoint sp in enemySpawns)
        {
            sp.despawn();
        }
    }

    public List<float> getLimits()
    {
        if (!scrollHorizontal && !scrollVertical)
        {
            return null;
        }
        List<float> barriers = new List<float>();

        if (scrollHorizontal && scrollVertical)
        {
            barriers.Add(cameraLimits[0].position.x);
            barriers.Add(cameraLimits[1].position.x);
            barriers.Add(cameraLimits[2].position.y);
            barriers.Add(cameraLimits[3].position.y);
        }
        else if (scrollHorizontal)
        {
            barriers.Add(cameraLimits[0].position.x);
            barriers.Add(cameraLimits[1].position.x);
        }
        else if (scrollVertical)
        {
            barriers.Add(cameraLimits[0].position.y);
            barriers.Add(cameraLimits[1].position.y);
        }

        return barriers;
    }
 }
