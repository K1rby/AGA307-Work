using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetSize
{
    Small,
    Medium,
    Large,
    //------
    COUNT
}

public class Target : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    public TargetSize targetSize;
    float scaleFactor = 1;

    float targetMoveDistance = 150f;
    float targetMoveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TargetMove());
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit()
    {
        meshRenderer.material.color = Color.red;
        Destroy(gameObject, 0.2f);
    }

    IEnumerator TargetMove()
    {
        for (int i = 0; i < targetMoveDistance; i++)
        {
            transform.Translate(Vector3.left * targetMoveSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.3f);
        transform.Rotate(Vector3.up * 180f);
        yield return new WaitForSecondsRealtime(0.3f);
        StartCoroutine(TargetMove());
    }

    void SetUp()
    {
        switch (targetSize)
        {
            case TargetSize.Small:
                scaleFactor = 1;
                transform.localScale = Vector3.one * scaleFactor;
                targetMoveSpeed = 20f;
                targetMoveDistance = 200f;
                break;
            case TargetSize.Medium:
                scaleFactor = 2;
                transform.localScale = Vector3.one * scaleFactor;
                targetMoveSpeed = 15f;
                targetMoveDistance = 175f;
                break;
            case TargetSize.Large:
                scaleFactor = 3;
                transform.localScale = Vector3.one * scaleFactor;
                targetMoveSpeed = 10f;
                targetMoveDistance = 150f;
                break;
        }
    }
}
