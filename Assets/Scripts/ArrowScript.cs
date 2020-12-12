using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public GameObject arrowPrefab;
    public PlayerScript playerScript;
    public GameObject dummyArrow;
    private MeshRenderer[] _meshRenderers;
    private float _arrowVelocity = 30f;
    public WeaponStatus weaponStatus;

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderers = dummyArrow.GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireArrow()
    {
        var bowAttack = weaponStatus.weaponAttack;
        var playerAttack = weaponStatus.playerScript.playerStats.playerAttack;
        GameObject newArrow = Instantiate(arrowPrefab) as GameObject;
        newArrow.transform.position = transform.position;
        newArrow.transform.rotation = transform.rotation;
        Rigidbody rb = newArrow.GetComponent<Rigidbody>();
        newArrow.GetComponent<Arrow>().SetDamage(bowAttack, playerAttack);
        rb.velocity = Camera.main.transform.forward * _arrowVelocity;
    }

    
    
    public void ShowArrow()
    {
        foreach (var mesh in _meshRenderers)
        {
            mesh.enabled = true;
        }
    }

    public void DontShowArrow()
    {
        foreach (var mesh in _meshRenderers)
        {
            mesh.enabled = false;
        }
    }
}
