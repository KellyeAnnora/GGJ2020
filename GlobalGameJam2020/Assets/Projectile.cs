using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float hitForce = 1000f;

    public Camera myCam;

    public GameObject blast;

    void Update()
    {
        RaycastHit hit;
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * hitForce, Color.red);

        if (Physics.Raycast(ray, out hit, hitForce))
        {
        }
        if (Input.GetKeyDown(KeyCode.Space)) ;
        {
            Instantiate(blast, transform.position, Quaternion.LookRotation(ray.direction));

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForceAtPosition(ray.direction * hitForce, hit.point);
                Debug.Log("Hit");
            }

        }
    }
}
