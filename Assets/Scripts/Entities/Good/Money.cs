using System;
using UnityEngine;

namespace Pramchuk
{
    public class Money: FallableObject
    {
        [SerializeField] private int value;
        public static Action<int> addMoney;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                addMoney?.Invoke(value);
                gameObject.SetActive(false);
            }
        }
    }
}