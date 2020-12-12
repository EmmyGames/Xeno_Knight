using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.UI;

public class BowStats : MonoBehaviour
{
    /*public Text AttackValue;
    public Text DurabilityValue;*/

    private BoxCollider[] weaponColliders;
    private SkinnedMeshRenderer _skinnedMeshRenderer;
    private bool _isCollected = false;
    private Collider _player;
    public GameObject arrow;

    private void Start()
    {
        _skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        weaponColliders = GetComponents<BoxCollider>();
        weaponColliders[1].enabled = false;
        _skinnedMeshRenderer.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && !_isCollected)
        {
            _player = other;
            weaponColliders[0].enabled = false;
            _skinnedMeshRenderer.enabled = false;
            _isCollected = true;
            /*
             * add item to inventory
             */
            /*AttackValue.text = "Attack: " + weapon.attack.ToString();
            DurabilityValue.text = "Durability: " + weapon.durability.ToString();*/
        }
    }

    public void EquipWeapon()
    {
        weaponColliders[1].enabled = true;
        _skinnedMeshRenderer.enabled = true;
    }

    public void UnEquipWeapon()
    {
        weaponColliders[1].enabled = false;
        _skinnedMeshRenderer.enabled = false;
    }

    public void CreatArrow()
    {
        
    }
}

