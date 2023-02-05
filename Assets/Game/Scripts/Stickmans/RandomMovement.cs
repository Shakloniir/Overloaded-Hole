using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 randomDestination;
    float timer = 0f;
    float waitTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        randomDestination = RandomNavmeshLocation(50f);
        waitTime = Random.Range(0, 0.1f);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            if (agent.enabled)
            {
                if (!agent.pathPending && agent.remainingDistance < 0.3f)
                {
                    randomDestination = RandomNavmeshLocation(50f);
                    agent.destination = randomDestination;
                    waitTime = Random.Range(0,0.1f);
                    timer = 0f;
                }
            }
        }
    }

    Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
