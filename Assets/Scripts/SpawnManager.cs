using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject bigBallPrefab;
    private float spawnRangeXX = 53.0f;
    private float spawnRangeX = 36.0f;
    private float spawnRangeZ = 3.05f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBigBalls", 2, 1.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnBigBalls()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX, spawnRangeXX), 19, spawnRangeZ);
        Instantiate(bigBallPrefab, spawnPos, bigBallPrefab.transform.rotation);
    }
}
