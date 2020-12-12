using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float startingHealth = 100;
    public  float currentHealth;
    //public AttackBehavior attack;
    private CanvasGroup enemyHealthBar;

    Animator anim;
    ParticleSystem hitParticles;
    public Slider enemySlider;

    public bool isDead;

    private int _isDead;
    private int _isMoving;
    private int _isSprinting;
    private int _isAttacking;
    private int _isADS;

    //public NavMeshAgent nav; //****IDK if either of these are being used or if you want to turn it off****
    //public Rigidbody body; 
    void Start()
    {
        anim = GetComponent<Animator>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        //nav = GetComponent<NavMeshAgent>();
        //body = GetComponent<Rigidbody>();
        currentHealth = startingHealth;
        // attack = GetComponent<AttackBehavior>();
        enemySlider.gameObject.SetActive(false);

        _isDead = Animator.StringToHash("isDead");
        _isAttacking = Animator.StringToHash("isAttacking");
        _isSprinting = Animator.StringToHash("isSprinting");
        _isMoving = Animator.StringToHash("isMoving");
        _isADS = Animator.StringToHash("isADS");
    }

    private void Update()
    {
        if (currentHealth < startingHealth)
        {
            enemySlider.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    public void TakeDamage (float amountDamage) //if particle system: , Vector3 hitPoint
    {
        this.currentHealth -= amountDamage;
        enemySlider.value = currentHealth;

        if (isDead)
            return; //exit function
        
        //hitParticles.transform.position.hitPoint;
        hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        anim.SetBool(_isDead, isDead);
        Destroy(gameObject, 1.5f);
    }
}

