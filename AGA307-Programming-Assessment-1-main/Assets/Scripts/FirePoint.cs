using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 1000f;
    public Transform firingPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject newProjectile;
            newProjectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(firingPoint.forward * projectileSpeed);
            Destroy(newProjectile, 2f);
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            print(hit.collider.name);

            if (hit.collider.CompareTag("Target"))
            {
                hit.collider.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }
}
