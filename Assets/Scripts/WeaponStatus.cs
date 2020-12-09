using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatus : MonoBehaviour
{
    public PlayerScript playerScript;
    public CharacterButton meleeButton;
    public CharacterButton rangeButton;
    public CharacterButton shieldButton;

    public Weapon heldWeapon = null;
    public WeaponType weaponType;
    public int weaponAttack;

    public int weaponTypeInt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (meleeButton.getWeapon() != null)
            {
                heldWeapon = meleeButton.getWeapon();
                weaponAttack = heldWeapon.attack;
                weaponType = heldWeapon.MyWeaponType;
                playerScript.sword.GetComponent<WeaponStats>().EquipWeapon();
                playerScript.bow.GetComponent<WeaponStats>().UnEquipWeapon();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (rangeButton.getWeapon() != null)
            {
                heldWeapon = rangeButton.getWeapon();
                weaponAttack = heldWeapon.attack;
                weaponType = heldWeapon.MyWeaponType;
                playerScript.sword.GetComponent<WeaponStats>().UnEquipWeapon();
                playerScript.bow.GetComponent<WeaponStats>().EquipWeapon();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            heldWeapon = null;
        }

        if (heldWeapon == null)
        {
            weaponTypeInt = 0;
        }
        else switch (weaponType)
        {
            case WeaponType.Melee:
                weaponTypeInt = 1;
                break;
            case WeaponType.Range:
                weaponTypeInt = 2;
                break;
        }
    }
}
