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
    float scaleFactor = 2;

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
                //scaleFactor = 2;
                transform.localScale = Vector3.one * scaleFactor;
                break;
            case TargetSize.Medium:
                //scaleFactor = 4;
                transform.localScale = Vector3.one * scaleFactor;
                break;
            case TargetSize.Large:
                //scaleFactor = 6;
                transform.localScale = Vector3.one * scaleFactor;
                break;
        }
    }
}
