using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanFall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<RagdollEnable>().RagdollModeOn();
        }
    }
}
