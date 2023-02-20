using System.Collections.Generic;
using UnityEngine;

namespace Pramchuk
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerScript player;
        [SerializeField] private CanvasManager canvasManager;
        [SerializeField] private MotherObjectPool _pool;
        [SerializeField] private List<EnemiesSpawner> spawners = new List<EnemiesSpawner>();
        [SerializeField] private SpawnTrigger spawnTrigger;
        [SerializeField] private WindowsSpawner windowsSpawner;
        [SerializeField] private RoomsSpawner roomsSpawner;

        private void AddSpawner(EnemiesSpawner tempSpawner)
        {
            spawners.Add(tempSpawner);
            tempSpawner.SetPool(_pool);
        }

        private void Awake()
        {
            Money.addMoney += Smthing;
            spawnTrigger.SpawnLevel += roomsSpawner.SpawnRoom;
            spawnTrigger.SpawnLevel += windowsSpawner.SpawnWindows;
            KillZone.killPlayer += StopGame;
            Enemy.killPlayer += StopGame;
            EnemiesSpawner.RequestPool += AddSpawner;
        }

        private void OnDisable()
        {
            Money.addMoney -= Smthing;
            spawnTrigger.SpawnLevel -= roomsSpawner.SpawnRoom;
            spawnTrigger.SpawnLevel -= windowsSpawner.SpawnWindows;
            KillZone.killPlayer -= StopGame;
            Enemy.killPlayer -= StopGame;
            EnemiesSpawner.RequestPool -= AddSpawner;
        }


        void StopGame()
        {
            //loseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        void ResumeGame()
        {
            Time.timeScale = 1f;
        }

        void Smthing(int value)
        {
            Debug.Log(value);
        }
    }
}
