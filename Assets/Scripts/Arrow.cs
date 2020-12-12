using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody _rb;

    private int _arrowAttack = 0;
    private int _playerAttack = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(_rb.velocity) * Quaternion.Euler(90, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().TakeDamage(_playerAttack + _arrowAttack);
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            Destroy(gameObject, 5);
        }

        /*if (!other.gameObject.CompareTag("Player"))
        {
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            Destroy(gameObject, 5);
        }*/
    }

    public void SetDamage(int arrowDamage, int playerDamage)
    {
        _arrowAttack = arrowDamage;
        _playerAttack = playerDamage;
    }
}
