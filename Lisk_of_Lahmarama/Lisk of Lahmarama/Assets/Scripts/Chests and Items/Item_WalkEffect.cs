using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_WalkEffect : MonoBehaviour
{
    public string effectId = "null";

    public string statId = "null";
    public float statChange = 0f;
    public GameObject magic;
    SharedResources players;

    void Start()
    {
        players = FindObjectsOfType<SharedResources>()[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.gameObject.GetComponent<PlayerInput>() != null)
        {
            if (magic != null)
            {
                other.gameObject.GetComponent<PlayerInput>().specialSpell = magic;
            }
            else
            {
                if (effectId != "null")
                {
                    other.gameObject.GetComponent<EffectList>().doEffect(effectId);
                }
                else
                {
                    if (statId == "money")
                    {
                        players.gameObject.GetComponent<SharedResources>().addMoney(statChange);
                    }
                    else if (statId == "health")
                    {
                        other.gameObject.GetComponent<PlayerInput>().health += 20;
                        if (other.gameObject.GetComponent<PlayerInput>().health > other.gameObject.GetComponent<PlayerInput>().healthMAX)
                        {
                            other.gameObject.GetComponent<PlayerInput>().health = other.gameObject.GetComponent<PlayerInput>().healthMAX;
                        }
                    }
                    else if (statId == "key")
                    {
                        players.gameObject.GetComponent<SharedResources>().addKeys((int)statChange);
                    }
                    else if (statId == "GreatswordWeapon")
                    {
                        other.gameObject.GetComponent<PlayerInput>().weaponType = 1;
                    }
                    else if (statId == "SwordWeapon")
                    {
                        other.gameObject.GetComponent<PlayerInput>().weaponType = 0;
                    }
                    else
                    {
                        other.gameObject.GetComponent<PlayerInput>().statChange(statId, statChange);
                        string playnum = "";
                        if (other.gameObject.GetComponent<PlayerInput>().playerNumber == 1)
                        {
                            playnum = "Buff1";
                        }
                        else
                        {
                            playnum = "Buff2";
                        }
                        if (statId == "atk")
                        {
                            GameObject.FindGameObjectWithTag(playnum).GetComponent<Buffs>().slots[0].SetActive(true);
                        }
                        else if (statId == "def")
                        {
                            GameObject.FindGameObjectWithTag(playnum).GetComponent<Buffs>().slots[1].SetActive(true);
                        }
                        else if (statId == "dex")
                        {
                            GameObject.FindGameObjectWithTag(playnum).GetComponent<Buffs>().slots[2].SetActive(true);
                        }
                        else if (statId == "mag")
                        {
                            GameObject.FindGameObjectWithTag(playnum).GetComponent<Buffs>().slots[3].SetActive(true);
                        }
                        else if (statId == "manaMAX")
                        {
                            GameObject.FindGameObjectWithTag(playnum).GetComponent<Buffs>().slots[4].SetActive(true);
                        }
                        else if (statId == "jump")
                        {
                            GameObject.FindGameObjectWithTag(playnum).GetComponent<Buffs>().slots[5].SetActive(true);
                        }
                        else if (statId == "speed")
                        {
                            GameObject.FindGameObjectWithTag(playnum).GetComponent<Buffs>().slots[6].SetActive(true);
                        }
                        else if (statId == "manaRegenSpeed")
                        {
                            GameObject.FindGameObjectWithTag(playnum).GetComponent<Buffs>().slots[7].SetActive(true);
                        }
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}
