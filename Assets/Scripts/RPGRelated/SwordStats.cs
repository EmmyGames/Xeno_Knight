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
    public WeaponStatus weaponStatus;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        weaponColliders = GetComponents<BoxCollider>();
        weaponColliders[1].enabled = false;
        _meshRenderer.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !weaponStatus.playerScript.playerAnimation.anim.GetBool(weaponStatus.playerScript.playerAnimation.shouldMove))
        {
            Debug.Log("hit");
            var swordAttack = weaponStatus.weaponAttack;
            var playerAttack = weaponStatus.playerScript.playerStats.playerAttack;
            other.GetComponent<EnemyHealth>().TakeDamage(playerAttack + swordAttack);
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
