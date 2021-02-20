using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public GameObject batPrefab;
    public float heightIncrement;
    public float spawnTime;
    private float yPos = 0f;
    void Start()
    {
        StartCoroutine(SpawnBats());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnBats()
    {
        while (true)
        {
            //float randomXPos = Random.Range(leftSpawnPos, rightSpawnPos);
            Instantiate(batPrefab, new Vector2(0, yPos), Quaternion.identity);
            yPos += heightIncrement;
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
