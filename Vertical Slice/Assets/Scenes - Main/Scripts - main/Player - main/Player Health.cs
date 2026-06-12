using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    public float currentHealth;

    public TMP_Text healthtext;
    // below is the image for the health added 
    public Image healthBarFill; 

    private SpriteRenderer sr;
    public Transform respawnPoint;
    public PlayerMovementV1 movementScript;
    public float respawnDelay = 1.5f;
    private Rigidbody2D rb; 
    private Animator animator;
    private AudioSource audioSource;

    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;
    private GameObject[] jumpPowerUps; 
    public bool isDead = false; 

    private void Start()
    {
        currentHealth = MaxHealth;
        sr = GetComponent<SpriteRenderer>();
         rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        UpdateHealthUI();
        jumpPowerUps = GameObject.FindGameObjectsWithTag("JPowerUp");
        Debug.Log("Current player health: " + currentHealth);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);

        Debug.Log("Player took damage. Current health: " + currentHealth);

        if (currentHealth > 0 && audioSource != null && hurtSound != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }

        UpdateHealthUI();
        if (currentHealth > 0)
        {
            StartCoroutine(DamageFlash());
        }
        

        if (currentHealth <= 0 && !isDead)
        {
            Debug.Log("Player is dead");
            if (audioSource != null && deathSound != null)
            {
                audioSource.PlayOneShot(deathSound);
            }

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
    private void ResetSpikeHeads()
    {
        SpikeHead[] spikeHeads = FindObjectsOfType<SpikeHead>();

        foreach (SpikeHead spike in spikeHeads)
        {
            spike.ResetSpikeHead();
        }
    }
    IEnumerator Respawn ()
    {
        isDead = true;
        if (healthtext != null)
            healthtext.text = "You Died! Respawning...(hint star is a powerup)";
        if (movementScript != null)
            movementScript.enabled = false;

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (animator != null)
            animator.SetTrigger("Die");

        yield return new WaitForSeconds(respawnDelay);

        transform.position = respawnPoint.position;

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
       
        currentHealth = MaxHealth;
        ResetPowerUps();
        ResetSpikeHeads(); 
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
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / MaxHealth;
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