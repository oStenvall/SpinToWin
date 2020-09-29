using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update

    [HideInInspector] public int ammo = 0;
    [HideInInspector] public string weaponEquipped = "";
    public TextMeshProUGUI ammoDisplay;
    public GameObject ammoPanel;

    public GameObject driver;
    public GameObject gravityDisc;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Bullet")
    //    {
    //        ammo++;
    //    }
    //}

    void Start()
    {

        if (ammo <= 0)
        {
            driver.SetActive(false);
            gravityDisc.SetActive(false);
        }
        else if (weaponEquipped == "GravityDisc") 
        {
            driver.SetActive(false);
            gravityDisc.SetActive(true);
        }else if(weaponEquipped == "Driver")
        {
            gravityDisc.SetActive(false);
            driver.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (weaponEquipped == "GravityDisc")
        {
            if (ammo > 0)
            {
                ammoPanel.SetActive(true);
                driver.SetActive(false);
                gravityDisc.SetActive(true);
                ammoDisplay.text = weaponEquipped + "s Left: " + ammo.ToString();
            }
            else
            {
                gravityDisc.SetActive(false);
                ammoPanel.SetActive(false);
            }
        }
        else if (weaponEquipped == "Driver")
            if (ammo > 0)
            {
                ammoPanel.SetActive(true);
                gravityDisc.SetActive(false);
                driver.SetActive(true);
                ammoDisplay.text = weaponEquipped + "s Left: " + ammo.ToString();
            }
            else
            {
                ammoPanel.SetActive(false);
                driver.SetActive(false);
            }

    }
}
