using UnityEngine;

public class SpikeHead : EnemyDamage
{
    [Header("Spike Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float range;

    // range will be used to see how far the spike will be ^
    [SerializeField] private float checkDelay;
    private float checkTimer;

    // attack direction
    private Vector3 attackDirection;

    // this means its going to have 4 elements not for not less
    private Vector3[] directions = new Vector3[4];

    private bool attacking;
    private Vector3 startingPosition; 

    private void OnEnable()
    {
        startingPosition = transform.position;
        Stop();
    }
    public void ResetSpikeHead()
    {
        transform.position = startingPosition;
        Stop();
    }

    private void Update()
    {
        // move spikehead to destination only if attacking
        if (attacking)
        {
            transform.Translate(attackDirection * Time.deltaTime * speed);
        }
        else
        {
            checkTimer += Time.deltaTime;

            if (checkTimer > checkDelay)
            {
                CheckForPlayer();
                checkTimer = 0f;
            }
        }
    }

    private void CheckForPlayer()
    {
        CalculateDirections();

        // check if spikehead sees player in all 4 directions
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i] * range, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                directions[i],
                range,
                playerLayer
            );

            if (hit.collider != null && !attacking)
            {
                attacking = true;
                attackDirection = directions[i];
                checkTimer = 0f;

                Debug.Log("Player detected!");
                break;
            }
        }
    }

    private void CalculateDirections()
    {
        directions[0] = transform.right;      // right direction
        directions[1] = -transform.right;     // left direction
        directions[2] = transform.up;         // up direction
        directions[3] = -transform.up;        // down direction
    }

    private void Stop()
    {
        // set direction to zero so it does not move
        attackDirection = Vector3.zero;
        attacking = false;
        checkTimer = 0f;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        // stops once it has hit something
        Stop();
    }
}