using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public int damage = 10; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Something collided with trap:" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit the trap");
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.Takedamage(damage);
            }
            else
            {
                Debug.Log("No playerHealth script found");
            }
        }
    }
}
