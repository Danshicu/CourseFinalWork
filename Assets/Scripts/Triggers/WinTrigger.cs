using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pramchuk
{
    [RequireComponent(typeof(Collider))]
    public class WinTrigger : MonoBehaviour
    {
        private Collider _collider;
        public Action win;
        void Awake()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                win?.Invoke();
            }
        }

        public void SetHeigth(int heigth)
        {
            transform.position = new Vector3(transform.position.x, heigth+transform.position.y, transform.position.z);
        }
    }
}
