using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public Bullet projectilePrefab;   //Gets the Bullet script from the Projectile prefab
    public Transform firingPoint;
    public LayerMask targetLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Bullet newProjectile;
            newProjectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            Destroy(newProjectile.gameObject, 2f);

            RaycastHit hitInfo;
            Debug.DrawRay(firingPoint.position, firingPoint.forward * 1000f, Color.blue, 1f);

            if(Physics.Raycast(firingPoint.position, firingPoint.forward, out hitInfo, 1000f, targetLayer))
            {
                Target target = hitInfo.collider.GetComponent<Target>();
                if(target != null)
                {
                    target.OnHit();
                }

                Debug.Log("Hit " + hitInfo.collider.gameObject.name);
            }
        }
    }

}
