using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    public Transform respawnLocation;      // Optional: where player respawns
    public ParticleSystem confettiEffect;  // Optional particle effect
    public Color activatedColor = Color.green;

    private SpriteRenderer sr;
    private bool activated = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated)
            return;

        if (collision.CompareTag("Player"))
        {
            PlayerHealth health = collision.GetComponent<PlayerHealth>();

            if (health != null)
            {
                // If no specific respawn point is assigned,
                // use the checkpoint's own position.
                if (respawnLocation != null)
                    health.respawnPoint = respawnLocation;
                else
                    health.respawnPoint = transform;
            }

            // Play confetti if assigned
            if (confettiEffect != null)
            {
                confettiEffect.Play();
            }

            // Change color to show activation
            if (sr != null)
            {
                sr.color = activatedColor;
            }

            Debug.Log("Checkpoint activated!");

            activated = true;
        }
    }
}