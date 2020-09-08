using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    //public GameObject pickupEffect;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D player)
    {
        PlayerInventory pi = player.GetComponent < PlayerInventory >();
        pi.ammo = 3;
        pi.weaponEquipped = "Driver";
        Destroy(gameObject);
    }
}
