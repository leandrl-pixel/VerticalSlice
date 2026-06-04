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
        fade = 0.5f;
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
            Debug.Log (fade);
        }
    }

    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(disableDelay);

        gameObject.SetActive(false);
    }
}

// notes I need to change something in regards to the fade or something to do with the dissolve it needs to be set at 0 and then change the value
//also the dissolve effect does not trigger back to normal it stays in place at 0 once it is completely 
// maybe not actually the effects work as intended, the dissolving from the object dissolves properly and everything resets as intended 