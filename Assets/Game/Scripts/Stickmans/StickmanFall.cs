using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanFall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("sa");
        GetComponent<RagdollEnable>().RagdollModeOn();
    }
}
