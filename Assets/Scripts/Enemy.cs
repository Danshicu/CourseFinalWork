using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{
    public static Action StopGame;
    private Collider _mCollider;

    public Rigidbody rigidbody() => GetComponent<Rigidbody>();
    void Awake()
    {
        _mCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            StopGame?.Invoke();
        }
    }
}
