using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro; 

public class PlayerHealth : MonoBehaviour
{

    public float MaxHealth = 100;
    public float currentHealth;
    // public Text healthtext;
    // il probably make a text health ui later this is lowkey tough
    public Transform respawnPoint; 

    private void Start()
    {
        currentHealth = MaxHealth;
        Debug.Log("Current player health:" + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage current health:" + currentHealth); 

        if (currentHealth <= 0)
        {
            Debug.Log("player is dead");
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
