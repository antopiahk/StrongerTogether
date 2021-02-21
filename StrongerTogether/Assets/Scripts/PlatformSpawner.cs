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

    private float yPos = -2.5f;
    public void Start()
    {
        StartCoroutine(SpawnPlatform());
    }


    IEnumerator SpawnPlatform()
    {
        while (true)
        {
            float randomXPos = Random.Range(leftSpawnPos, rightSpawnPos);
            int randomPlatform = Random.Range(0, platformPrefabs.Length*2);
            if(randomPlatform == 0 || randomPlatform == 1 || randomPlatform == 2)
            {
                randomPlatform = 0;
            }
            else
            {
                randomPlatform = 1;
            }
            GameObject platformLeft = Instantiate(platformPrefabs[randomPlatform], new Vector2(randomXPos, yPos), Quaternion.identity); // Left side
            GameObject platformRight = Instantiate(platformPrefabs[randomPlatform], new Vector2(-randomXPos, yPos), Quaternion.identity); // Right side
            if(randomPlatform == 2)
            {
                platformLeft.GetComponent<MovingPlatformScript>().isLeftPlatform = true;
                platformRight.GetComponent<MovingPlatformScript>().isLeftPlatform = false;
            }
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
