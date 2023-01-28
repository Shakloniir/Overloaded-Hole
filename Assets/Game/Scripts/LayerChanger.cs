using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        int LayerIgnoreRaycast = LayerMask.NameToLayer("InHole");
        other.gameObject.layer = LayerIgnoreRaycast;
    }
}
