using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Pramchuk
{
    public class ObjectsPool<T> where T:MonoBehaviour
    {
        private List<T> _pool;
        private readonly T _prefab;
        public int Count { private set; get; }
        private readonly Transform _location;
    
        public ObjectsPool(T prefab, int count, Transform place)
        {
            _location = place;
            _prefab = prefab;
            Count = count;
            CreatePool();
        }
    
        private void CreatePool()
        {
            _pool = new List<T>();
            for (int i = 0; i < Count; i++)
            {
                CreateObject();
            }
        }
    
        private T CreateObject()
        {
            var newObject = Object.Instantiate(_prefab, _location);
            newObject.gameObject.SetActive(false);
            _pool.Add(newObject);
            return newObject;
        }
    
        public bool HasFreeElement(out T element)
        {
            foreach (var item in _pool)
            {
                if (!item.gameObject.activeInHierarchy)
                {
                    element = item;
                    item.gameObject.SetActive(true);
                    return true;
                }
            }
            element = null;
            return false;
        }
    
        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
            {
                return element;
            }
            return null;
        }
    }
}
