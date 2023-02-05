using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanSpawner : MonoBehaviour
{
    public int maxStickmanCount;
    public int currentStickmanCount;
     
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject stickmanPrefab;

    int randomNumber;

    private void Start()
    {
        for (int i = 0; currentStickmanCount < maxStickmanCount; i++)
        {
            currentStickmanCount++;
            SpawnStickman();
        }
    }
    public void SpawnStickman()
    {
        randomNumber = Random.Range(0, spawnPoints.Length);
        GameObject stickman = Instantiate(stickmanPrefab, spawnPoints[randomNumber].position, spawnPoints[randomNumber].rotation);
    }
}
