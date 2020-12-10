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

    bool isDead; //wether or not enemy is dead

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
        this.hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        //set animation trigger for death
        /*this.nav.enabled = false;
        this.GetComponent<NavMeshAgent>().enabled = false;
        this.attack.enabled = false;*/

        Destroy(this.gameObject, 1.5f);
    }
}
