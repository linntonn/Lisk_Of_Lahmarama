using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedResources : MonoBehaviour
{
    public float money = 0f;
    public float level = 1f;
    public float exp_limit = 1000f;
    public float exp_modifier = 1.2f;
    public float stat_increase = 2.0f;

    public float current_exp = 0f;

    public int current_keys = 0;

    GameObject[] targets;
    GameObject player1;
    GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Player");
        player1 = targets[0];
        player2 = targets[1];
    }

    public void addXP(float xp)
    {
        float actual_xp;
        while(xp > 0)
        {
            actual_xp = Mathf.Min(exp_limit - current_exp, xp);
            xp -= actual_xp;
            current_exp += actual_xp;
            if(current_exp >= exp_limit)
            {
                level += 1f;
                current_exp = 0f;
                exp_limit *= exp_modifier;

                player1.GetComponent<PlayerInput>().allStatChange(stat_increase);
                player2.GetComponent<PlayerInput>().allStatChange(stat_increase);
            }
        }
    }

    /**ADD THIS TO PLAYERINPUT
    public void allStatChange(float num)
    {
        statDict["healthMAX"] += num;
        statDict["manaMAX"] += num;
        statDict["atk"] += num;
        statDict["mag"] += num;
        statDict["def"] += num;
        statDict["dex"] += num;
        statDict["speed"] += num;
        statDict["jump"] += num;
        statDict["manaRegenSpeed"] += num;
    }
    **/

    public void addMoney(float num)
    {
        money += num;
    }

    public float getMoney()
    {
        return money;
    }

    public void addKeys(int num)
    {
        current_keys += num;
    }

    public bool useKey(int num)
    {
        if (current_keys >= num && current_keys > 0 && num > 0)
        {
            current_keys -= num;
            return true;
        }
        else
        {
            return false;
        }
    }
}
