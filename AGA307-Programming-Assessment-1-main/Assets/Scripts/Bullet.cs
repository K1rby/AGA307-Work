using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody.AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Target target = collision.gameObject.GetComponent<Target>();
            if(target != null)
            {
                target.OnHit();
                Destroy(this.gameObject);
            }
        }
    }
}
