using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust this to control the speed of the circle
    public Vector2 initialDirection; // Initial direction set when spawning

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = initialDirection.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)

    {
         if (collision.gameObject.tag == "Player")
        {
            // Destroy the circle when it collides with the player
            Destroy(gameObject);
        }
        else
    {
        // Reflect the direction based on the collision normal
        Vector2 newDirection = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
        rb.velocity = newDirection * speed;

        }   
         }
}
