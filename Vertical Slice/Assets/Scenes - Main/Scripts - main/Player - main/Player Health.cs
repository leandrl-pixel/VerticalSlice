using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    public float currentHealth;

    public TMP_Text healthtext;

    private SpriteRenderer sr;
    public Transform respawnPoint;
    public PlayerMovementV1 movementScript;
    public float respawnDelay = 1.5f;
    private Rigidbody2D rb; 
    private Animator animator;
    private GameObject[] jumpPowerUps; 
    public bool isDead = false; 

    private void Start()
    {
        currentHealth = MaxHealth;
        sr = GetComponent<SpriteRenderer>();
         rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        UpdateHealthUI();
        jumpPowerUps = GameObject.FindGameObjectsWithTag("JPowerUp");
        Debug.Log("Current player health: " + currentHealth);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);

        Debug.Log("Player took damage. Current health: " + currentHealth);

        UpdateHealthUI();
        if (currentHealth > 0)
        {
            StartCoroutine(DamageFlash());
        }
        

        if (currentHealth <= 0 && !isDead)
        {
            Debug.Log("Player is dead");
            StartCoroutine(Respawn()); 
        }
    }
    private void ResetPowerUps()
    {
        
        foreach(GameObject powerUp in jumpPowerUps)
        {
            powerUp.SetActive(true); 
        }
    }
    IEnumerator Respawn ()
    {
        isDead = true;
        if (healthtext != null)
            healthtext.text = "You Died! Respawning...(hint star is a powerup, more content coming soon)";
        if (movementScript != null)
            movementScript.enabled = false;

        if (rb != null)
            rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f; 
        //fixed bug where trap on edge makes player move 
        rb.constraints = RigidbodyConstraints2D.FreezeAll; 

        if (rb != null) 
            rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //prevents all movement and physics form reacting
        // after respawn the freezeroation goes back to normal 


        if (animator != null)
            animator.SetTrigger("Die"); 

        yield return new WaitForSeconds(respawnDelay);
        transform.position = respawnPoint.position;
        currentHealth = MaxHealth;
        ResetPowerUps();
        movementScript.hasExtraJump = false;
        UpdateHealthUI() ;
       // what this respawn does it is it influences how the health responds and allows for the poweer ups to reappear after player dies 

        if(animator != null)
        {
            animator.Play("Idle"); 
        }


        if (movementScript != null)
            movementScript.enabled = true; 
        isDead = false;

    }
    void UpdateHealthUI()
    {
        if (healthtext != null)
        {
            healthtext.text = "HP: " + currentHealth;
        }
    }

    IEnumerator DamageFlash()
    {
        if (sr != null)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            sr.color = Color.white;
        }
    }
}