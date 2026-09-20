using UnityEngine;

public class EnemyDirectChase : MonoBehaviour
{
    public float speed = 3f;
    private Transform playerTransform;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (playerTransform != null)
        {
            // Calculate the direction from enemy to player
            Vector2 direction = (playerTransform.position - transform.position).normalized;

            // Move the Kinematic Rigidbody towards the player
            Vector2 targetPosition = rb.position + direction * speed * Time.fixedDeltaTime;
            rb.MovePosition(targetPosition);
        }
    }
}