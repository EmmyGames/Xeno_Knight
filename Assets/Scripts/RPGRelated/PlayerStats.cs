using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerScript playerScript;
    public int totalHealth;
    public int currentHealth;
    public int totalStamina;
    public int currentStamina;
    public int playerAttack;
    public int playerDefense;
    public int totalEXP;
    public int currentEXP;
    public int playerLevel;
    void Start()
    {
        playerLevel = 1;
        playerAttack = 3;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * when current EXP > totalEXP
         * level up
         * increase stats
         * restore health
         * currentEXP - totalEXP
         * totalEXP += expCurve
         * 
         */
    }

    public void GainEXP(int xp)
    {
        currentEXP += xp;
        if (currentEXP > totalEXP)
        {
            playerLevel++;
            currentEXP -= totalEXP;
            totalEXP += (int)Math.Ceiling(totalEXP * 1.1f);
        }
    }
}
