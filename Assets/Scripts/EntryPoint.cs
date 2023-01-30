using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerScript player;
    [SerializeField] private Canvas mLoseCanvas;
    private void Awake()
    {
        Enemy.StopGame += Stop;
    }

    private void OnDisable()
    {
        Enemy.StopGame -= Stop;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Stop()
    {
       mLoseCanvas.gameObject.SetActive(true);
       Time.timeScale = 0f;
    }
}
