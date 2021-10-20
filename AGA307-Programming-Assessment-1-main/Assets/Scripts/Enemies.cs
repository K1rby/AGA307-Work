using System.Collections;
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
    float moveDistance = 500f;

    public EnemyType enemyType;
    public int enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Move());
        }*/
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
}
