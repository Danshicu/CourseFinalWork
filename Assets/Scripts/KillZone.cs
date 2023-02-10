using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class KillZone : MonoBehaviour
{
    private Collider _collider;
    static public Action KillPlayer;
    void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KillPlayer?.Invoke();
        }
    }
}
