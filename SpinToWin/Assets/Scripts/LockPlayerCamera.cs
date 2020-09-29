using UnityEngine;

public class LockPlayerCamera : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerMovement>().CameraIsFollowingPlayer = false;
        }
    }
}
