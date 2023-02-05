using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gravity : MonoBehaviour
{
    public float radius;
    public float power;
    public bool isPlayer;
    void FixedUpdate()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit && hit.transform != transform && hit.attachedRigidbody)
            {
                if (hit.gameObject.GetComponent<SticmkanListControl>() != null)
                {
                    if (isPlayer)
                    {
                        int LayerIgnoreRaycast = LayerMask.NameToLayer("InHoleP");

                        if (hit.gameObject.layer == LayerIgnoreRaycast)
                        {
                            Vector3 difference = hit.transform.position - transform.position;
                            hit.attachedRigidbody.AddForce(difference.normalized * power, ForceMode.Force);
                        }
                            
                    }
                    else
                    {
                        int LayerIgnoreRaycast = LayerMask.NameToLayer("InHoleE");

                        if (hit.gameObject.layer == LayerIgnoreRaycast)
                        {
                            Vector3 difference = hit.transform.position - transform.position;
                            hit.attachedRigidbody.AddForce(difference.normalized * power, ForceMode.Force);
                        }
                    }
                   
                }

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}