using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

            if (count >= 3)
            {
                Destroy(other.gameObject);
                count = 0;
            }
            count++;
        }
    }
}