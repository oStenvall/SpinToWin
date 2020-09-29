using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject gravityDiscBulletPrefab;
    public GameObject driverBulletPrefab;

    float timeUntilFure;
    PlayerMovement pm;
    private PlayerInventory pi;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
        pi = gameObject.GetComponent<PlayerInventory>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && timeUntilFure < Time.time)
        {
            if (pi.ammo > 0)
            {
                pi.ammo--;
                ShootDistanceDriver();
                timeUntilFure = Time.time + fireRate;
            }

        }
    }

    void ShootDistanceDriver()
    {
        float angle = pm.isFacingLeft ? 180f : 0f;
        if(pi.weaponEquipped == "Driver")
        {
            Instantiate(driverBulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        }else if(pi.weaponEquipped == "GravityDisc")
        {
            Instantiate(gravityDiscBulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        }
    }
}
