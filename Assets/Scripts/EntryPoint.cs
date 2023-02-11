using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerScript player;
    [SerializeField] private Canvas mLoseCanvas;
    [SerializeField] private MotherObjectPool _pool;
    [SerializeField] private List<EnemiesSpawner> spawners = new List<EnemiesSpawner>();
    [SerializeField] private LevelSpawner levelSpawner;
    [SerializeField] private WindowsSpawner windowsSpawner;

    private void AddSpawner(EnemiesSpawner tempSpawner)
    {
        spawners.Add(tempSpawner);
        tempSpawner.SetPool(_pool);
    }
    private void Awake()
    {
        levelSpawner.SpawnLevel += windowsSpawner.SpawnWindows;
        KillZone.KillPlayer += Stop;
        Enemy.StopGame += Stop;
        EnemiesSpawner.RequestPool += AddSpawner;
    }

    private void OnDisable()
    {
        levelSpawner.SpawnLevel += windowsSpawner.SpawnWindows;
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
