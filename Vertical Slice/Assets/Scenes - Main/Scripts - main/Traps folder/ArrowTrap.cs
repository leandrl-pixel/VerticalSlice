using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    private float cooldownTimer;
    private void Attack()
    {
        //reset the cooldown timer 
        cooldownTimer = 0;

        //everytime we shoot we need to reset the psosiiton 
        arrows[FindArrow()].transform.position = firePoint.position;

        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();

        // then we need to set the direction of the posisiton 

    }
    //make a private interger that will make fireballs 
    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;
            
        }
        return 0; 
        
        //added the semicolon might change this
    }
    
    

    private void Update()
    {
        //now we need to incremente the cooldown in every frame so we need to do 
        cooldownTimer += Time.deltaTime;


        // now we need to call the attack method somewhere 
        if(cooldownTimer >= attackCooldown)
            Attack();
    }
}
