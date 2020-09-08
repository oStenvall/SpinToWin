using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update

    [HideInInspector] public int ammo = 0;
    [HideInInspector] public string weaponEquipped = "";
    public Text ammoDisplay;

    // Update is called once per frame
    void Update()
    {
        if(ammo > 0)
        {
            ammoDisplay.text = weaponEquipped + "s Left: " + ammo.ToString();
        }
        else 
        {
            ammoDisplay.text = "";
        }
       
    }
}
