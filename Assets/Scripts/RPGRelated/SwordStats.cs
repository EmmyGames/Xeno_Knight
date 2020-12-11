using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStats : MonoBehaviour
{
    /*public Text AttackValue;
    public Text DurabilityValue;*/

    private BoxCollider[] weaponColliders;
    private MeshRenderer _meshRenderer;
    private bool _isCollected = false;
    private Collider _player;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        weaponColliders = GetComponents<BoxCollider>();
        weaponColliders[1].enabled = false;
        _meshRenderer.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && !_isCollected)
        {
            _player = other;
            weaponColliders[0].enabled = false;
            _meshRenderer.enabled = false;
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
        _meshRenderer.enabled = true;
    }

    public void UnEquipWeapon()
    {
        weaponColliders[1].enabled = false;
        _meshRenderer.enabled = false;
    }
}
