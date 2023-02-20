using System;
using UnityEngine;

namespace Pramchuk
{
    [RequireComponent(typeof(Collider))]
    public class SpawnTrigger : MonoBehaviour
    {
        public Action SpawnLevel;
        [SerializeField] private float windowHeight = 3f;
        private Vector3 CurrentPosition;
    
        private void Awake()
        {
            CurrentPosition = transform.position;
        }
    
        private void OnCollisionEnter(Collision collision)
        {
            SpawnLevel?.Invoke();
            CurrentPosition.y += windowHeight;
            transform.position = CurrentPosition;
        }
    }

}
