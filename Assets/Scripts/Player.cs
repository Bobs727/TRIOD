using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    private float _speed;
    private Vector3 _direction;
    
    public void Start()
    {
       _direction = new Vector3(0f, 0f, 0f);
       _speed = 0.5f;
    }

    private void FixedUpdate() 
    {
        player.transform.Translate(_direction * Time.deltaTime * _speed);
    }

    public void OnRightButton()
    {
        _direction = Vector3.right;
    }

    public void OnLeftButton()
    {
        _direction = Vector3.left;
    }   
}