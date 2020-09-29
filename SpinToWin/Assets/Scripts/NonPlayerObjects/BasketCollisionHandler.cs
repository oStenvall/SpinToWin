
using UnityEngine;

public class BasketCollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            anim.SetBool("IsHit", true);
        }
    }
}
