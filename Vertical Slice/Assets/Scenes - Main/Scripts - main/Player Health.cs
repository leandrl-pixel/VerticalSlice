using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float MaxHealth = 100;
    public float currentHealth;
   // public Text healthtext;
   // il probably make a text health ui later this is lowkey tough

    private void Start()
    {
        currentHealth = MaxHealth;
        Debug.Log("Current player health:" + currentHealth);
    }

    public void Takedamage(int damage)
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
