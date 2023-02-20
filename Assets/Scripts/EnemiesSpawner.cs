using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pramchuk
{
    public class EnemiesSpawner : MonoBehaviour
    {
        private MotherObjectPool _pool;
        
        [SerializeField] private Collider deathZoneCollider;
        
        [SerializeField] private float minimalSpawnInterval = 3.5f;
        [SerializeField] private float maximalSpawnInterval = 8f;
        
        [SerializeField] private int minSpawnCount = 2;
        [SerializeField] private int maxSpawnCount = 5;
        
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private float forceMultiplayer=5f;
    
        [SerializeField] private Animation closingAnimation;
        
        public static Action<EnemiesSpawner> RequestPool;
        public void SetPool(MotherObjectPool generalPool)
        {
            this._pool = generalPool;
        }
    
    
        private IEnumerator Spawn(int spawnCount)
        {
            for (int i =0; i<spawnCount; i++)
            {
                yield return new WaitForSeconds(Random.Range(minimalSpawnInterval, maximalSpawnInterval));
                _pool.GetRandomObject(out var enemy);
                if (enemy != null)
                {
                    enemy.gameObject.SetActive(true);
                    enemy.transform.position = spawnPosition.position;
                    enemy.rigidbody().AddForce(Vector3.back * forceMultiplayer, ForceMode.Impulse);
                }
                else
                {
                    yield return new WaitForSeconds(maximalSpawnInterval / 2f);
                }
            }
            closingAnimation.Play();
        }
        
        private void OnEnable()
        {
            int spawnCount = Random.Range(minSpawnCount, maxSpawnCount);
            RequestPool?.Invoke(this);
            StartCoroutine(Spawn(spawnCount));
        }
    
        public void CloseWindow() => deathZoneCollider.enabled = false;
        
        
    }

}
