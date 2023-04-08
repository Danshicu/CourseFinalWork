using System;
using UnityEngine;

namespace Pramchuk
{
    [RequireComponent(typeof(Collider))]
    public class SpawnTrigger : MonoBehaviour
    {
        public Action spawnLevel;
        [SerializeField] private float windowHeight = 3f;
        private Vector3 CurrentPosition;
    
        private void Awake()
        {
            CurrentPosition = transform.position;
        }
    
        private void OnCollisionEnter(Collision collision)
        {
            spawnLevel?.Invoke();
            CurrentPosition.y += windowHeight;
            transform.position = CurrentPosition;
        }
    }

}
