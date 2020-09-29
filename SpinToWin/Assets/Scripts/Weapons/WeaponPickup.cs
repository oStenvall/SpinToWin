using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    //public GameObject pickupEffect;

    private PlayerInventory pi;


    void Start()
    {
        pi = GameObject.FindObjectOfType<PlayerInventory>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("GravityDisc")){
            Pickup(other, "GravityDisc");
        }
        else if (other.CompareTag("Driver")){
            Pickup(other, "Driver");
        }
        else if (other.CompareTag("GravityAmmo"))
        {
            PickUpFromCrate("GravityDisc");
        }
        else if (other.CompareTag("DriverAmmo"))
        {
            PickUpFromCrate("Driver");
        }
    }

    void Pickup(Collider2D weapon, string weaponType)
    {
        pi.ammo = 0;
        pi.ammo = 3;
        pi.weaponEquipped = weaponType;
        Destroy(weapon.gameObject);
    }

    void PickUpFromCrate(string weaponType)
    {
        pi.ammo = 0;
        pi.ammo = 5;
        pi.weaponEquipped = weaponType;
    }
}
