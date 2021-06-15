using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyKill : MonoBehaviour
{
    public float exp;
    public GameObject money;
    public float min_money = 1f;
    public float max_money = 5f;

    SharedResources players;

    // Start is called before the first frame update
    void Start()
    {
        players = FindObjectsOfType<SharedResources>()[0];
    }

    void OnDestroy()
    {
        if (players != null)
        {
            players.gameObject.GetComponent<SharedResources>().addXP(exp);
            players.gameObject.GetComponent<SharedResources>().addMoney(Mathf.Round(Random.Range(min_money, max_money)));
        }
        
    }
}
