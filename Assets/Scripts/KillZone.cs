using System;
using UnityEngine;

namespace Pramchuk
{
   [RequireComponent(typeof(Collider))]
   public class KillZone : MonoBehaviour
   {
       public static Action killPlayer;
       
       private void OnCollisionEnter(Collision collision)
       {
           if (collision.gameObject.CompareTag("Player"))
           {
               killPlayer?.Invoke();
           }
       }
   } 
}

