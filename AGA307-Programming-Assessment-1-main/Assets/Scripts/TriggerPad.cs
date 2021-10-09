using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    public GameObject sphere;
    public MeshRenderer meshRenderer;
    public float growSpeed = 0.1f;
    public float originalScale;

    void Start()
    {
        originalScale = sphere.transform.localScale.x;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            meshRenderer.material.color = Color.green;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sphere.transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sphere.transform.localScale = Vector3.one * originalScale;
            meshRenderer.material.color = Color.cyan;
        }
    }
}

