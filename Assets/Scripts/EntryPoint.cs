using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerScript player;
    [SerializeField] private Canvas mLoseCanvas;
    [SerializeField] private List<EnemiesSpawner> spawners = new List<EnemiesSpawner>();
    [SerializeField] private MotherObjectPool _pool;

    private void AddSpawner(EnemiesSpawner tempSpawner)
    {
        spawners.Add(tempSpawner);
        tempSpawner.SetPool(_pool);
    }
    private void Awake()
    {
        KillZone.KillPlayer += Stop;
        Enemy.StopGame += Stop;
        EnemiesSpawner.RequestPool += AddSpawner;
    }

    private void OnDisable()
    {
        KillZone.KillPlayer -= Stop;
        Enemy.StopGame -= Stop;
        EnemiesSpawner.RequestPool -= AddSpawner;
    }
    

    void Stop()
    {
       mLoseCanvas.gameObject.SetActive(true);
       Time.timeScale = 0f;
    }
}
