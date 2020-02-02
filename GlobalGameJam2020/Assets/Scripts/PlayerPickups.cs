using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickups : MonoBehaviour
{
    public int partCount = 0;

    private void Start()
    {
        partCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            partCount += 1;
            Debug.Log("Part count is " + partCount);
        }
    }
}
