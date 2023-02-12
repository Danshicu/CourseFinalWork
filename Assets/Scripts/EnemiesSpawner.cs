using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private float minimalSpawnInterval=5f;
    [SerializeField] private float maximalSpawnInterval=9f;
    [SerializeField] private MotherObjectPool _pool;
    public static Action<EnemiesSpawner> RequestPool;
    [SerializeField] private int minSpawnCount=2;
    [SerializeField] private int maxSpawnCount=5;
    
    public void SetPool(MotherObjectPool generalPool)
    {
        this._pool = generalPool;
    }


    private IEnumerator Spawn(int spawnCount)
    {
        for (int i =0; i<spawnCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(minimalSpawnInterval, maximalSpawnInterval));
            var enemy = _pool.GetRandomObject();
            enemy.gameObject.SetActive(true);
            enemy.transform.position = this.transform.position;
            
        }
    }
    
    private void OnEnable()
    {
        int spawnCount = Random.Range(minSpawnCount, maxSpawnCount);
        RequestPool?.Invoke(this);
        StartCoroutine(Spawn(spawnCount));
    }
    
}
