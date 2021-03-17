using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    private float _speed;
    private float _rotationSpeed;
    private Vector3 _direction;
    
    public void Start()
    {
       _direction = new Vector3(0f, 0f, 0f);
       _speed = 0.5f;
       _rotationSpeed = 2f;
    }

    private void FixedUpdate() 
    {
        Moving();
        Rotation();    
    }

    public void OnRightButton()
    {
        _direction = Vector3.right;
    }

    public void OnLeftButton()
    {
        _direction = Vector3.left;
    }   


    private void Rotation()
    {
        float angle =  transform.eulerAngles.z;
        Debug.Log(_direction.x * angle *  _rotationSpeed * Time.deltaTime);
        player.transform.Rotate(0, 0,  _direction.x * angle *  _rotationSpeed * Time.deltaTime);
    }

    private void Moving()
    {
        player.transform.Translate(_direction * _speed * Time.deltaTime);
    }
}



// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     public GameObject player;
//     private float _speed;
//     private Vector3 _direction;

//     private float _rotation;
//     private float _rotationSpeed;
    
//     public void Start()
//     {
//        _direction = new Vector3(0f, 0f, 0f);
//        _speed = 0.5f;
//        _rotation = 0f;
//        _rotationSpeed = 120f;
//     }

//     private void FixedUpdate() 
//     {
//         Moving();  
//         Debug.Log(player.transform.rotation);
//     }

//     public void OnRightButton()
//     {
//         _direction = Vector3.right;
       
//         _rotation += _rotationSpeed;
    
//         Rotation();
//     }

//     public void OnLeftButton()
//     {
//         _direction = Vector3.left;

//         _rotation -= _rotationSpeed;
        
//         Rotation();
//     }   

//     private void Rotation()
//     {
//         float angle =  transform.eulerAngles.z;
//         player.transform.Rotate(0, 0, _rotation * angle *  Time.deltaTime, Space.Self);
//     }

//     private void Moving()
//     {
//         player.transform.Rotate(0, 0, 0);
//         player.transform.Translate(_direction * _speed * Time.deltaTime);
//     }
// }