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
    
    public bool isDead = false; 

    private void Start()
    {
        currentHealth = MaxHealth;
        sr = GetComponent<SpriteRenderer>();
         rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        UpdateHealthUI();

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
    IEnumerator Respawn ()
    {
        isDead = true;
        if (healthtext != null)
            healthtext.text = "You Died! Respawning...";
        if (movementScript != null)
            movementScript.enabled = false;

        if (rb != null)
            rb.velocity = Vector2.zero;

        if (animator != null)
            animator.SetTrigger("Die"); 

        yield return new WaitForSeconds(respawnDelay);
        transform.position = respawnPoint.position;
        currentHealth = MaxHealth; 
        UpdateHealthUI() ;

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