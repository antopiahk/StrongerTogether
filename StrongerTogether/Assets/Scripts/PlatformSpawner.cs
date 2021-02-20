using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public int spawnTime;
    public GameObject[] platformPrefabs;

    public float leftSpawnPos, rightSpawnPos;
    public float heightGap;

    private float yPos = 0f;
    public void Start()
    {
        StartCoroutine(SpawnPlatform());

    }


    IEnumerator SpawnPlatform()
    {
        while (true)
        {
            float randomXPos = Random.Range(leftSpawnPos, rightSpawnPos);
            Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], new Vector2(randomXPos, yPos), Quaternion.identity);
            Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], new Vector2(-randomXPos, yPos), Quaternion.identity);
            yPos += heightGap;
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
