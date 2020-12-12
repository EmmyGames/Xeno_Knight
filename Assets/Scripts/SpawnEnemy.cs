using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemyList;
    public bool isAlive;
    public GameObject enemy;
    void Awake()
    {
        enemy = Instantiate(enemyList[Random.Range(0, enemyList.Length)], transform.position,
            Quaternion.identity);
        isAlive = true;
    }

    private void Update()
    {
        if (isAlive && enemy.GetComponent<EnemyHealth>().isDead)
        {
            StartCoroutine(EnemyKilled());
            isAlive = false;
        }
    }

    IEnumerator EnemyKilled()
    {
        yield return new WaitForSeconds(50);
        enemy = Instantiate(enemyList[Random.Range(0, enemyList.Length)], transform.position,
            Quaternion.identity);
        isAlive = true;
    }
}
