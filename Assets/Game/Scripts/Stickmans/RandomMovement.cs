using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RivalBlackHole : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public List<GameObject> capturedStickmen = new List<GameObject>();

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        GameObject nearestStickman = FindNearestStickman();
        if (nearestStickman == null)
        {
            MoveTowardsTarget();
        }
        else
        {
            MoveTowardsStickman(nearestStickman);
        }
    }

    GameObject FindNearestStickman()
    {
        GameObject[] stickmen = GameObject.FindGameObjectsWithTag("Stickman");
        if (stickmen.Length == 0)
        {
            return null;
        }

        GameObject nearest = stickmen[0];
        float minDistance = Vector3.Distance(transform.position, stickmen[0].transform.position);
        for (int i = 1; i < stickmen.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, stickmen[i].transform.position);
            if (distance < minDistance)
            {
                nearest = stickmen[i];
                minDistance = distance;
            }
        }

        return nearest;
    }

    void MoveTowardsStickman(GameObject stickman)
    {
        float distance = Vector3.Distance(transform.position, stickman.transform.position);
        if (distance < agent.stoppingDistance)
        {
            capturedStickmen.Add(stickman);
            stickman.SetActive(false);
            SortCapturedStickmen();
        }
        else
        {
            agent.destination = stickman.transform.position;
        }
    }

    void SortCapturedStickmen()
    {
        capturedStickmen.Sort((x, y) => Vector3.Distance(transform.position, x.transform.position)
            .CompareTo(Vector3.Distance(transform.position, y.transform.position)));
    }

    void MoveTowardsTarget()
    {
        if (capturedStickmen.Count > 0)
        {
            agent.destination = capturedStickmen[0].transform.position;
        }
        else
        {
            agent.destination = target.position;
        }
    }
}
