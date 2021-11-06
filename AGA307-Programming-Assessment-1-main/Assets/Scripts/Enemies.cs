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

public class Enemies : MonoBehaviour
{
    public Animator animator;

    private GameManager _GM;

    float moveDistance = 500f;

    public EnemyType enemyType;
    public int enemyHealth;

    public float enemyHitScore = 1f; //Score received when enemy is hit
    public float enemyDeathScore = 100f; //Score received when enemy dies

    int playerDamage = 10;

    float idleTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Move());
        SetUp();
        _GM = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Hit();
        }

        if(idleTimer <= 0f)
        {
            SeekTarget();
        }
    }

    IEnumerator Move()
    {
        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSecondsRealtime(1f);

        transform.Rotate(Vector3.up * 180f);

        yield return new WaitForSecondsRealtime(1f);

        StartCoroutine(Move());
    }

    public virtual void SetUp()
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
            default:
                Debug.Log("Invalid type selected");
                break;
        }
    }

    public virtual void Hit()
    {
        animator.SetTrigger("Hit");
        enemyHealth -= playerDamage;
        GameEvents.ReportEnemyHit(this);
        _GM.AddScore(enemyHitScore);

        if(enemyHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void SeekTarget()
    {

    }

    public virtual void Die()
    {
        animator.SetTrigger("Die");
        GameEvents.ReportEnemyDied(this);
        _GM.AddScore(enemyDeathScore);
        EnemyManager.instance.EnemyDied(this);
        StopAllCoroutines();
        Destroy(gameObject, 3f);
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
