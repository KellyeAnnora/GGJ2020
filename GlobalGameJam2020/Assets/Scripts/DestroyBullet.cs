using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{

    void DestroyObjectDelayed()
    {
        Destroy(gameObject, 5);
    }

}
