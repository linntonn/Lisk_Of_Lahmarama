using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    private Slider healthBar;
    private PlayerHealth playerHealth;
    public bool isMana;
    public bool isBoss;

    private void Start()
    {
        //playerHealth = player.GetComponent<PlayerInput>().health;
        if (!isMana && !isBoss)
        {
            healthBar = GetComponent<Slider>();
            healthBar.maxValue = player.GetComponent<PlayerInput>().healthMAX;
            healthBar.value = player.GetComponent<PlayerInput>().health;
        }
        else if (isBoss)
        {
            healthBar = GetComponent<Slider>();
            healthBar.maxValue = player.GetComponent<EarthDragonAI>().healthMAX;
            healthBar.value = player.GetComponent<EarthDragonAI>().health;
        }
        else
        {
            healthBar = GetComponent<Slider>();
            healthBar.maxValue = player.GetComponent<PlayerInput>().manaMAX;
            healthBar.value = player.GetComponent<PlayerInput>().mana;
        }
    }

    public void SetHealth(int hp)
    {
        if (!isMana && !isBoss)
        {
            healthBar.maxValue = player.GetComponent<PlayerInput>().healthMAX;
            healthBar.value = player.GetComponent<PlayerInput>().health;
        }
        else if (isBoss)
        {
            healthBar = GetComponent<Slider>();
            healthBar.maxValue = player.GetComponent<EarthDragonAI>().healthMAX;
            healthBar.value = player.GetComponent<EarthDragonAI>().health;
        }
        else
        {
            healthBar.value = player.GetComponent<PlayerInput>().manaMAX;
            healthBar.value = player.GetComponent<PlayerInput>().mana;
        };
    }

    private void FixedUpdate()
    {
        if (!isMana && !isBoss)
        {
            healthBar.value = player.GetComponent<PlayerInput>().health;
        }
        else if (isBoss)
        {
            healthBar.value = player.GetComponent<EarthDragonAI>().health;
        }
        else
        {
            healthBar.value = player.GetComponent<PlayerInput>().mana;
        }
    }
}
