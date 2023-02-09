using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    public bool isPlayerArea;

    private void OnTriggerEnter(Collider other)
    {
        if (isPlayerArea)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponentInParent<PlayerController>().DisableControl();
            }
        }
        else
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponentInParent<EnemyBlackHole>().DisableControl();
            }
        }
    }
}
