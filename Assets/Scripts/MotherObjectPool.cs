using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class EnemyObject
    {
        [SerializeField] public Enemy prefab;
        [SerializeField] public int count;
        [SerializeField] public Transform place;
    }
public class MotherObjectPool : MonoBehaviour
{
    [SerializeField] private List<EnemyObject> entityVariations;
    [SerializeField] private List<ObjectsPool<Enemy>> entities = new List<ObjectsPool<Enemy>>();

    private void Awake()
    {
        foreach (var entity in entityVariations)
        {
            var newpool = new ObjectsPool<Enemy>(entity.prefab, entity.count, entity.place);
            entities.Add(newpool);
            int number = entities.Count;   
        }
    }

    public Enemy GetRandomObject()
    {
        int elementNumber = Random.Range(0, entities.Count);
        var item = entities[elementNumber].GetFreeElement();
        return item;
    }
}
