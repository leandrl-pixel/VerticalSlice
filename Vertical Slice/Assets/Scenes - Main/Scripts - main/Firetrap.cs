using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private int damage; 
    // in the youtbe video the guy did float but im doing int instead not sure if this will mess up

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay; 
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; // when the trap gets triggered 
    private bool active; // when the trap gets is activated and can hurt the player 

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
                StartCoroutine(ActivateFiretrap());

            if (active)
                collision.GetComponent<PlayerHealth>().TakeDamage(damage); 
        }
            
    }
    private IEnumerator ActivateFiretrap()
    {
        // turn the color of the sprite into red to notify the player
        triggered = true;
        spriteRend.color = Color.red; 

        // wait for delay, acitvate trap, turn on animation, and return color back to normal
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; // turn the sprite back to its inital color with this 
        active = true;
        anim.SetBool("activated", true); 

        // wait until x seconds then decative trap and rest all viarables and animator 
        yield return new WaitForSeconds(activeTime); 
        active = false;
        triggered = false;
        anim.SetBool("activated", false); 
    }
}
