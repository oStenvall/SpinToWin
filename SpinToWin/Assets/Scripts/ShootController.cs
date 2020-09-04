using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bulletPrefab;

    float timeUntilFure;
    PlayerMovement pm;
}
