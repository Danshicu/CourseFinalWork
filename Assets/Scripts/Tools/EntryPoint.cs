using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pramchuk
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private WinTrigger winTrigger;
        [SerializeField] private MoneyCounter moneyCounter;
        [SerializeField] private CanvasManager canvasManager;
        [SerializeField] private MotherObjectPool pool;
        [SerializeField] private SpawnTrigger spawnTrigger;
        [SerializeField] private WindowsSpawner windowsSpawner;
        [SerializeField] private RoomsSpawner roomsSpawner;
        [SerializeField] private int minimalLevelHeight = 60;
        [SerializeField] private int maximalLevelHeight = 80;

        private void AddSpawner(EnemiesSpawner tempSpawner)
        {
            tempSpawner.SetPool(pool);
        }

        private void Awake()
        {
            winTrigger.win += moneyCounter.SaveMoney;
            winTrigger.win += canvasManager.Win;
            winTrigger.win += PauseGame;
            canvasManager.pauseGame += PauseGame;
            canvasManager.resumeGame += ResumeGame;
            Money.addMoney += moneyCounter.AddMoney;
            moneyCounter.setMoney += canvasManager.SetCurrentMoney;
            spawnTrigger.spawnLevel += roomsSpawner.SpawnRoom;
            spawnTrigger.spawnLevel += windowsSpawner.SpawnWindows;
            KillZone.killPlayer += PauseGame;
            KillZone.killPlayer += canvasManager.Lose;
            Enemy.killPlayer += PauseGame;
            Enemy.killPlayer += canvasManager.Lose;
            EnemiesSpawner.requestPool += AddSpawner;
        }

        private void OnDisable()
        {
            winTrigger.win -= moneyCounter.SaveMoney;
            winTrigger.win -= canvasManager.Win;
            winTrigger.win -= PauseGame;
            canvasManager.pauseGame -= PauseGame;
            canvasManager.resumeGame -= ResumeGame;
            Money.addMoney -= moneyCounter.AddMoney;
            moneyCounter.setMoney -= canvasManager.SetCurrentMoney;
            spawnTrigger.spawnLevel -= roomsSpawner.SpawnRoom;
            spawnTrigger.spawnLevel -= windowsSpawner.SpawnWindows;
            KillZone.killPlayer -= PauseGame;
            KillZone.killPlayer -= canvasManager.Lose;
            Enemy.killPlayer -= PauseGame;
            Enemy.killPlayer -= canvasManager.Lose;
            EnemiesSpawner.requestPool -= AddSpawner;
        }

        private void Start()
        {
            ResumeGame();
            int levelEndHeight = Random.Range(minimalLevelHeight, maximalLevelHeight);
            winTrigger.SetHeigth(levelEndHeight*3);
        }


        void PauseGame()
        {
            Time.timeScale = 0f;
        }

        void ResumeGame()
        {
            Time.timeScale = 1f;
        }
        
    }
}
