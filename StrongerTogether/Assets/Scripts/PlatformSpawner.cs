using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public float spawnTime;
    public float destroyDelayTime;
    public GameObject[] platformPrefabs;
    private List<GameObject> platformsInScene;

    public float leftSpawnPos, rightSpawnPos;
    public float heightGap;

    private float yPos;
    public void Start()
    {
        StartCoroutine(SpawnPlatform());
    }


    IEnumerator SpawnPlatform()
    {
        while (true)
        {
            float randomXPos = Random.Range(leftSpawnPos, rightSpawnPos);
            GameObject platformLeft = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], new Vector2(randomXPos, yPos), Quaternion.identity);
            GameObject platformRight = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], new Vector2(-randomXPos, yPos), Quaternion.identity);
            StartCoroutine(DelayDestroyPlatform(platformLeft));
            StartCoroutine(DelayDestroyPlatform(platformRight));
            yPos += heightGap;
            yield return new WaitForSeconds(spawnTime/GameManager.instance.generalVelocity);
        }
    }

    IEnumerator DelayDestroyPlatform(GameObject _platform)
    {
        yield return new WaitForSeconds(5+destroyDelayTime/GameManager.instance.generalVelocity);
        Destroy(_platform);
    }
}
