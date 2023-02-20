using System.Collections.Generic;
using UnityEngine;

namespace Pramchuk
{
    public class WindowsSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject openedWindow;
        [SerializeField] private GameObject closedWindow;
        [SerializeField] private int windowCountPerLevel = 5;
        private readonly List<float> _positions = new();
        private Vector3 _currentPosition = new();
    
    
        private void AddRandomWindow(Vector3 currentPos)
        {
            int randomIndex = Random.Range(0, 10);
            if (randomIndex < 8)
            {
                Instantiate(closedWindow, currentPos, Quaternion.identity);
            }
            else
            {
                 Instantiate(openedWindow, currentPos, Quaternion.identity);
            }
        }
    
        public void SpawnWindows()
        {
            if (this.gameObject.activeInHierarchy)
            {
                foreach (var position in _positions)
                {
                    _currentPosition.x = position;
                    AddRandomWindow(_currentPosition);
                }
    
                _currentPosition.y += closedWindow.transform.localScale.y;
            }
        }
        void Awake()
        {
            _currentPosition.x = transform.position.x;
            _currentPosition.y = transform.position.y;
            _currentPosition.z = transform.position.z;
            float posX = transform.position.x - (windowCountPerLevel / 2 * closedWindow.transform.localScale.x);
            for (int i = 0; i < windowCountPerLevel; i++)
            {
                _positions.Add(posX);
                posX += closedWindow.transform.localScale.x;
            }
        }
    
        
    }

}
