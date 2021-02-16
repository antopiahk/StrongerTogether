using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platfromspawner : MonoBehaviour
{
    public int spawnTime;
    public GameObject platformPrefab;
    public void Start()
    {
        StartCoroutine(SpawnPlatform());
    }


    IEnumerator SpawnPlatform()
    {
        while(true)
        {
            Instantiate(platformPrefab, Vector2.zero, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
