using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    OneHand,
    TwoHand,
    Archer,
    //------
    COUNT
}

public class Enemies : GameBehaviour
{
    float moveDistance = 500f;

    public EnemyType enemyType;
    public int enemyHealth;

    public float enemyHitScore = 10f;
    public float enemyDeathScore = 100f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Hit(10);
        }
    }

    IEnumerator Move()
    {
        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSecondsRealtime(2f);

        transform.Rotate(Vector3.up * 180f);

        yield return new WaitForSecondsRealtime(2f);

        StartCoroutine(Move());
    }

    void SetUp()
    {
        switch (enemyType)
        {
            case EnemyType.Archer:
                enemyHealth = 50;
                break;
            case EnemyType.OneHand:
                enemyHealth = 100;
                break;
            case EnemyType.TwoHand:
                enemyHealth = 150;
                break;
        }
    }

    void Hit(int _damage)
    {
        enemyHealth -= _damage;
        GameEvents.ReportEnemyHit(this);
        _GM.AddScore(enemyHitScore);

        if(enemyHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameEvents.ReportEnemyDied(this);
        _GM.AddScore(enemyDeathScore);
        _EM.EnemyDied(this);
        StopAllCoroutines();
        Destroy(this.gameObject);
    }
}

public static class GameEvents
{
    public static event Action<Enemies> OnEnemyHit = null;
    public static event Action<Enemies> OnEnemyDied = null;

    public static void ReportEnemyHit(Enemies _enemy)
    {
        Debug.Log("Enemy " + _enemy.name + " was hit");
        OnEnemyHit?.Invoke(_enemy);
    }

    public static void ReportEnemyDied(Enemies _enemy)
    {
        Debug.Log("Enemy " + _enemy.name + " died");
        OnEnemyDied?.Invoke(_enemy);
    }
}
