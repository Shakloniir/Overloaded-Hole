using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChanger : MonoBehaviour
{
    public bool isPlayer;
    private void OnTriggerEnter(Collider other)
    {
     

        if(other.GetComponent<SticmkanListControl>() != null)
        {
            if (!other.GetComponent<SticmkanListControl>().IsInHole)
            {

                other.GetComponent<SticmkanListControl>().IsInHole = true;
            }
        }

        if (isPlayer)
        {
            int LayerIgnoreRaycast = LayerMask.NameToLayer("InHoleP");
            other.gameObject.layer = LayerIgnoreRaycast;

            if (other.tag == "Stickman")
            {
                FindObjectOfType<PlayerController>().Stickmans.Add(other.gameObject);
                other.GetComponentInParent<StickmanColors>().ChangeColor(false);
            }
        }
        else
        {
            int LayerIgnoreRaycast = LayerMask.NameToLayer("InHoleE");
            other.gameObject.layer = LayerIgnoreRaycast;
            if (other.tag == "Stickman")
            {
                FindObjectOfType<EnemyBlackHole>().caughtStickmen.Add(other.gameObject);
                other.GetComponentInParent<StickmanColors>().ChangeColor(true);
            }
        }
    }
  
}
