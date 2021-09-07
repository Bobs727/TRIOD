using System;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private int _speed = 2;
    
    private void FixedUpdate()
    {
        transform.Translate(_speed * new Vector2(0, -1) * Time.deltaTime, Space.World);
    }
}
