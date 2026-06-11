using System.Collections;
using UnityEngine;

public class FireTrapVTwo : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay = 1f;
    [SerializeField] private float activeTime = 2f;

    [Header("Damage Over Time")]
    [SerializeField] private float damageInterval = 1f;

    [Header("Audio")]
    [SerializeField] private AudioClip activateSound;

    private AudioSource audioSource;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered;
    private bool active;

    private float damageTimer = 0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (damageTimer > 0f)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!triggered)
            {
                StartCoroutine(ActivateFiretrap());
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && active && damageTimer <= 0f)
        {
            PlayerHealth health = collision.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
                damageTimer = damageInterval;
            }
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        triggered = true;
        spriteRend.color = Color.red;

        yield return new WaitForSeconds(activationDelay);

        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        if (audioSource != null && activateSound != null)
        {
            audioSource.PlayOneShot(activateSound);
        }

        yield return new WaitForSeconds(activeTime);

        active = false;
        triggered = false;
        anim.SetBool("activated", false);
        damageTimer = 0f;
    }
}