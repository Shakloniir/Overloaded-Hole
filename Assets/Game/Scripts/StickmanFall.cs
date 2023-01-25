using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanFall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().isTrigger = false;
    }
}
