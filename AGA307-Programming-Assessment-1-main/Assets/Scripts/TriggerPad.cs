using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    public GameObject sphere;
    public MeshRenderer meshRenderer;

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
            sphere.transform.localScale = Vector3.one * 0.01f * Time.deltaTime;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sphere.transform.localScale = Vector3.one;
            meshRenderer.material.color = Color.cyan;
        }
    }
}

