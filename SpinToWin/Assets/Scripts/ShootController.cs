﻿using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bulletPrefab;

    float timeUntilFure;
    PlayerMovement pm;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && timeUntilFure < Time.time)
        {
            PlayerInventory pi = gameObject.GetComponent<PlayerInventory>();
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
        Debug.Log(angle);
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
