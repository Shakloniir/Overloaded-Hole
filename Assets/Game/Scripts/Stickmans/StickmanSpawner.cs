using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanSpawner : MonoBehaviour
{
    public int maxStickmen;
    public int currentStickmen;
     
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] GameObject stickmanPrefab;

    int randomNumber;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            while (currentStickmen < maxStickmen)
            {
                float randomWaitTime = Random.Range(0.2f, 0.8f);
                yield return new WaitForSeconds(randomWaitTime);

                int randomIndex = Random.Range(0, spawnPositions.Length);
                Transform spawnTransform = spawnPositions[randomIndex];
                Instantiate(stickmanPrefab, spawnTransform.position, spawnTransform.rotation);

                currentStickmen++;
            }

            yield return new WaitUntil(() => currentStickmen < maxStickmen);
        }
    }
}
