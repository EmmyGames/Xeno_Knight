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

    private bool _changeWeapon = false;

    private SwordStats _swordStats;
    private BowStats _bowStats;
    // Start is called before the first frame update
    void Start()
    {
        _swordStats = playerScript.sword.GetComponent<SwordStats>();
        _bowStats = playerScript.bow.GetComponent<BowStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (meleeButton.getWeapon() != null)
            {
                heldWeapon = meleeButton.getWeapon();
                weaponAttack = heldWeapon.attack;
                weaponType = heldWeapon.MyWeaponType;
                _changeWeapon = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (rangeButton.getWeapon() != null)
            {
                heldWeapon = rangeButton.getWeapon();
                weaponAttack = heldWeapon.attack;
                weaponType = heldWeapon.MyWeaponType;
                
                _changeWeapon = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            heldWeapon = null;
            _changeWeapon = true;
        }

        if (_changeWeapon)
        {
            if (heldWeapon == null)
            {
                weaponAttack = 0;
                weaponTypeInt = 0;
                _swordStats.UnEquipWeapon();
                _bowStats.UnEquipWeapon();
                _changeWeapon = false;
            }
            else switch (weaponType)
            {
                case WeaponType.Melee:
                    weaponTypeInt = 1;
                    _swordStats.EquipWeapon();
                    _bowStats.UnEquipWeapon();
                    _changeWeapon = false;
                    break;
                case WeaponType.Range:
                    weaponTypeInt = 2;
                    _swordStats.UnEquipWeapon();
                    _bowStats.EquipWeapon();
                    _changeWeapon = false;
                    break;
            }
        }
    }
}
