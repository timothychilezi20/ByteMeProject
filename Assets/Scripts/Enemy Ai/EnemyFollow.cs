using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    public float Speed;
    public float knockbackForce = 10f;
    public float detectionRadius = 10f;

    private Rigidbody2D rb;
    private Transform CurrentPoint;
    private Transform player;
    private bool facingRight = false; // my enemy is initially facing left
    private bool isFollowingPlayer = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentPoint = PointB.transform;
        if (!facingRight)
        {
            Flip();
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= detectionRadius)
        {
            isFollowingPlayer = true;
        }
        else
        {
            isFollowingPlayer = false;
        }

        if (isFollowingPlayer)
        {
            Move();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void Move()
    {
        // Follow the player
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * Speed;

        // Flip the enemy to face the player
        if (direction.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 2f);
        Gizmos.DrawWireSphere(PointB.transform.position, 2f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
