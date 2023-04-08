using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pramchuk
{
  public class RoomsSpawner : MonoBehaviour
  {
      [SerializeField] private List<GameObject> roomPrefabs;
      [SerializeField] private float roomHeight = 3f;
      private Vector3 currentPosition = new Vector3();
  
      public void SpawnRoom()
      {
          Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Count)], currentPosition, quaternion.identity);
          currentPosition.y += roomHeight;
      }
      void Awake()
      {
          currentPosition.x = this.transform.position.x;
          currentPosition.y = this.transform.position.y;
          currentPosition.z = this.transform.position.z;
      }
      
      
  }  
}

