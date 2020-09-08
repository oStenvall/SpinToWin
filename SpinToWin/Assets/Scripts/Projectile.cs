using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 15f;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;

    public PlayerMovement pm;

    private void Start()
    {
        pm = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void setBulletDirection()
    {
        
        if (pm.gravityDirection == 0)
        {
            rb.velocity = transform.right * projectileSpeed;
        }
        else if (pm.gravityDirection == 1)
        {
            rb.velocity = transform.up * projectileSpeed;
        }
        else if (pm.gravityDirection == 2)
        {
            rb.velocity = -transform.right * projectileSpeed;
        }
        else // 3
        {
            rb.velocity = -transform.up * projectileSpeed;
        }
    }

    private void FixedUpdate()
    {
        setBulletDirection();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
