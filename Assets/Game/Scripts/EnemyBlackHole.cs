using UnityEngine;
using System.Collections.Generic;

public class EnemyBlackHole : MonoBehaviour
{
    public float speed = 1f;
    public Transform target;
    public List<GameObject> caughtStickmen;

    private void Start()
    {
        caughtStickmen = new List<GameObject>();
    }

    private void FixedUpdate()
    {
        GameObject nearestStickman = GetNearestStickman();

        if (nearestStickman != null)
        {
            target = nearestStickman.transform;
        }
        else
        {
            target = GameObject.FindWithTag("Target").transform;
        }

        if (caughtStickmen.Count < 35)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            target = GameObject.FindWithTag("Target").transform;
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private GameObject GetNearestStickman()
    {
        GameObject nearestStickman = null;
        float nearestDistance = float.MaxValue;

        GameObject[] allStickmen = GameObject.FindGameObjectsWithTag("Stickman");
        foreach (var stickman in allStickmen)
        {
            if (!caughtStickmen.Contains(stickman) && stickman.GetComponent<SticmkanListControl>().IsInHole == false)
            {
                float distance = Vector3.Distance(stickman.transform.position, transform.position);
                if (distance < nearestDistance)
                {
                    nearestStickman = stickman;
                    nearestDistance = distance;
                }
            }
        }

        return nearestStickman;
    }
}
