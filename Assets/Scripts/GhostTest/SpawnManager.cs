using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int maxCount;
    public int ghostCount;
    public float spawnTime;
    public float curTime;
    public Transform[] spawnPoints;
    public bool[] isSpawn;
    public GameObject ghost;

    // 귀신 처치 시 count 초기화
    public static SpawnManager _instance;
    private void Start()
    {
        isSpawn = new bool[spawnPoints.Length];
        for(int i = 0; i < isSpawn.Length; i++)
        {
            isSpawn[i] = false;
        }

        _instance = this;
    }
    private void Update()
    {
        if(curTime >= spawnTime && ghostCount < maxCount)
        {
            int x = Random.Range(0, spawnPoints.Length);
            if (!isSpawn[x])
            {
                SpawnEnemy(x);
            }
            
        }

        curTime += Time.deltaTime;
    }

    public void SpawnEnemy(int ranNum)
    {
        curTime = 0;
        ghostCount++;
        Instantiate(ghost, spawnPoints[ranNum]);
        isSpawn[ranNum] = true;
    }
}
