using UnityEngine;

public class Mouse : MonoBehaviour
{
    [Range(0.5f, 2.0f)]
    public float Speed;
    public float DistanceToAttack;

    private Player player;
    private Animator animator;
    private Settings settings;
    private bool isDead;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
        settings = Resources.Load<Settings>("Settings");
        EventsManager.PlayerDead += OnPlayerDead;
    }


    private void Update()
    {
        if (isDead)
        {
            return;
        }

        if (player == null || player.isDead)
        {
            return;
        }

        Vector3 playerSurfacePosition = player.transform.position;
        playerSurfacePosition.y = 0.0f;
        transform.LookAt(playerSurfacePosition, Vector3.up);

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if(distanceToPlayer < DistanceToAttack)
        {
            animator.SetTrigger("PlayerNear" + Random.Range(1, 3));
        } else
        {
            animator.SetTrigger("PlayerMovedAway");
            Vector3 directionToPlayer = playerSurfacePosition - transform.position;
            directionToPlayer.Normalize();
            transform.position += directionToPlayer * settings.MouseMovementSpeed * Time.deltaTime;
        }
    }

    private void OnPlayerDead()
    {
        animator.SetTrigger("PlayerDead");
    }

    /// <summary>
    /// Attack animation event callback.
    /// </summary>
    private void Attack()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer < DistanceToAttack)
        {
            player.GetHit();
        }
    }

    public void Die()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;
        animator.SetTrigger("MouseDead");
        EventsManager.OnMouseDead(this);
    }

    private void OnDestroy()
    {
        EventsManager.PlayerDead -= OnPlayerDead;
    }
}
