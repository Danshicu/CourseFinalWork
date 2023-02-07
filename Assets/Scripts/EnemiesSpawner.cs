using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private float minimalSpawnInterval;
    [SerializeField] private float maximalSpawnInterval;
    [SerializeField] private MotherObjectPool _pool;
    public static Action<EnemiesSpawner> RequestPool;

    public void SetPool(MotherObjectPool generalPool)
    {
        this._pool = generalPool;
    }


    private IEnumerator Spawn()
    {
        while (this.gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(Random.Range(minimalSpawnInterval, maximalSpawnInterval));
            var enemy = _pool.GetRandomObject();
            enemy.rigidbody().velocity = Vector3.zero;
            enemy.gameObject.SetActive(true);
            enemy.transform.position = this.transform.position;
            
        }
    }
    
    private void OnEnable()
    {
        RequestPool?.Invoke(this);
        StartCoroutine(Spawn());
    }
    
}
