using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAudio : MonoBehaviour
{
    [SerializeField] private AudioClip powerUpSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPowerUpSound()
    {
        Debug.Log("Playing powerup sound");

        if (audioSource != null && powerUpSound != null)
        {
            audioSource.PlayOneShot(powerUpSound);
        }
    }
}
