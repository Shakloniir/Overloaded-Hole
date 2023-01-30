using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanFall : MonoBehaviour
{
    public bool control;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<RagdollEnable>().RagdollModeOn();
            if (!control)
                other.GetComponent<BlendshapeCollider>().StickmanFall();
            control = true;
        }
    }
}
