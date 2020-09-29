using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileNoGrav : MonoBehaviour
{
    public float projectileSpeed = 15f;
    public float bulletDamage = 10f;
    public Rigidbody2D Rb;

    private PlayerMovement pm;

    private void Start()
    {
        pm = GameObject.FindObjectOfType<PlayerMovement>();
        setBulletDirection();
    }

    private void setBulletDirection()
    {
        if (pm.gravityDirection == 0)
        {
            Rb.velocity = transform.right * projectileSpeed;
        }
        else if (pm.gravityDirection == 1)
        {
            Rb.velocity = transform.up * projectileSpeed;
        }
        else if (pm.gravityDirection == 2)
        {
            Rb.velocity = -transform.right * projectileSpeed;
        }
        else // 3
        {
            Rb.velocity = -transform.up * projectileSpeed;
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
