using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Pramchuk
{
    public class ObjectsPool<T> where T:MonoBehaviour
    {
        private List<T> pool;
        private T prefab;
        public int count { private set; get; }
        private Transform location;
    
        public ObjectsPool(T prefab, int count, Transform place)
        {
            location = place;
            this.prefab = prefab;
            this.count = count;
            this.CreatePool();
        }
    
        private void CreatePool()
        {
            this.pool = new List<T>();
            for (int i = 0; i < count; i++)
            {
                this.CreateObject();
            }
        }
    
        private T CreateObject()
        {
            var newObject = Object.Instantiate(this.prefab, location);
            newObject.gameObject.SetActive(false);
            pool.Add(newObject);
            return newObject;
        }
    
        public bool HasFreeElement(out T element)
        {
            foreach (var item in pool)
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
            if (this.HasFreeElement(out var element))
            {
                return element;
            }
            return null;
        }
    }

}
