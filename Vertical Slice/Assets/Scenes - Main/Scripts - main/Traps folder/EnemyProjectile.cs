
using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        // incrememente the lifetime vairable 
        lifetime += Time.deltaTime; 
        
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        // base is a keyword that automatically lets you access the parent scirpt 
        // so when we write this line it means 
        // execute logic  from parent script first 
        gameObject.SetActive(false); //when this hit another collider this deactivates the gameobject
    }
}
