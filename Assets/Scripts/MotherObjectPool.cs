using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pramchuk
{
   [System.Serializable]
   public class EnemyObject<T> where T: MonoBehaviour
       {
           [SerializeField] public T prefab;
           [SerializeField] public int count;
           [SerializeField] public Transform place;
       }
   public class MotherObjectPool : MonoBehaviour
   {
       [SerializeField] private List<EnemyObject<FallableObject>> entityVariations;
       private List<ObjectsPool<FallableObject>> entities = new();
       private int totalCount;
   
       private void Awake()
       {
           foreach (var entity in entityVariations)
           {
               var newpool = new ObjectsPool<FallableObject>(entity.prefab, entity.count, entity.place);
               entities.Add(newpool);
               totalCount += entity.count;
           }
       }

       public void GetRandomObject(out FallableObject item)
       {
           int elementNumber = Random.Range(0, totalCount);
           item = null;
           int tempCount = 0;
           for (int i = 0; i < entities.Count; i++)
           {
               tempCount += entities[i].Count;
               if (tempCount >= elementNumber)
               {
                   item = entities[i].GetFreeElement();
                   break;
               }
           }

       }
   }
 
}
