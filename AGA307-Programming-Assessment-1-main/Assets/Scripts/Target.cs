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
    //transform.localScale = Vector3.one * scaleFactor;

    // Start is called before the first frame update
    void Start()
    {
        
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

    void SetUp()
    {
        switch (targetSize)
        {
            case TargetSize.Small:
                //targetHealth = 1;
                //scaleFactor = 1;
                transform.localScale = Vector3.one * scaleFactor;
                break;
            case TargetSize.Medium:
                //targetHealth = 2;
                //scaleFactor = 2;
                transform.localScale = Vector3.one * scaleFactor;
                break;
            case TargetSize.Large:
                //targetHealth = 3;
                //scaleFactor = 3;
                transform.localScale = Vector3.one * scaleFactor;
                break;
        }
    }
}
