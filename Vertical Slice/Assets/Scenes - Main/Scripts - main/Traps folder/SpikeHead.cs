
using UnityEditor.Rendering;
using UnityEngine;

public class SpikeHead : EnemyDamage
{
    
    [SerializeField] private float speed; 
    [SerializeField] private float range;

    // range will be used to see how far the spike will be ^
    [SerializeField] private float checkDelay;
    private float checkTimer;
    Vector3 destination;

    private Vector3[] directions = new Vector3[4];
    // this means its going to have 4 elements not for not less  

    private bool attacking; 

    private void Update()
    {
        // move spikehead to destination only if attacking
        if(attacking)
        transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer(); 
        }
    }
    private void CheckForPlayer()
    {
        CalculateDirections();
        // check if spikehead sees player in all 4 directions 
        for (int i = 0; i < directions.Length; i++)
        {

        }
    }
    private void CalculateDirections()
    {
        directions[0] = transform.right * range; // right direction 
        directions[1] = -transform.right * range; // left direction  
        directions[2] = transform.up * range; // up direction 
        directions[3] = -transform.up * range; // down direction 
    }
}
