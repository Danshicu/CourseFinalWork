using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Transform m_player;
    private Vector3 m_position;
    [SerializeField] private float horizontal_step;
    [SerializeField] private float vertical_step;
    void Awake()
    {
        m_player = gameObject.GetComponent<Transform>();
        //m_position = m_player.position;
    }

    void Update()
    {
        MyInput();
        m_player.position += Vector3.up * vertical_step;
    }

    void MyInput()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            m_player.position += Vector3.left*horizontal_step;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            m_player.position += Vector3.right*horizontal_step;
        }
    }
}
