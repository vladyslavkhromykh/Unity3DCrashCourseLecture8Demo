using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [Range(0.5f, 2.0f)]
    public float Speed;
    public float DistanceToAttack;
    public MouseSpawner spawner;

    private Player player;

    private Animator animator;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (player == null)
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
            transform.position += directionToPlayer * Speed * Time.deltaTime;
        }
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
        spawner.MouseDie();
    }

}
