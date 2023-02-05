using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHole : MonoBehaviour
{
    public bool isPlayer;
   
    private void OnTriggerExit(Collider other)
    {
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Default");
        other.gameObject.layer = LayerIgnoreRaycast;

        if (other.GetComponent<SticmkanListControl>() != null)
        {
            if (other.GetComponent<SticmkanListControl>().IsInHole)
            {
                other.GetComponent<SticmkanListControl>().IsInHole = false;
            }
        }

        if (isPlayer)
        {
            if (other.tag == "Stickman")
                FindObjectOfType<PlayerController>().Stickmans.Remove(other.gameObject);
        }
        else
        {
            FindObjectOfType<EnemyBlackHole>().caughtStickmen.Remove(other.gameObject);
        }
    }
}
