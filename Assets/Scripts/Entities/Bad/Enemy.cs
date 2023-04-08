using System;
using UnityEngine;



namespace Pramchuk
{
    public class Enemy : FallableObject
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
