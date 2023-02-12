using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public static Action StopGame;
    //private Collider _mCollider;
    [SerializeField] private float disableTime;

    public Rigidbody rigidbody() => GetComponent<Rigidbody>();
     void Awake()
     {
         //_mCollider = GetComponent<Collider>();
         _rigidbody = GetComponent<Rigidbody>();
     }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            StopGame?.Invoke();
        }
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(disableTime);
        this.gameObject.SetActive(false);
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnEnable()
    {
        StartCoroutine(Disable());
    }
}
