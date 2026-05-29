using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    private Material material;

    private bool isDissolving = false;
    private float fade = 1f;

    public float dissolveSpeed = 0.5f;
    public float disableDelay = 1.5f;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void OnEnable()
    {
        fade = 1f;
        isDissolving = false;

        material.SetFloat("_Fade", fade);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDissolving = true;

            StartCoroutine(DisableAfterDelay());
        }
    }

    private void Update()
    {
        if (isDissolving)
        {
            fade -= Time.deltaTime * dissolveSpeed;
            fade = Mathf.Clamp01(fade);

            material.SetFloat("_Fade", fade);
        }
    }

    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(disableDelay);

        gameObject.SetActive(false);
    }
}