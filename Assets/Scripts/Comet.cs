using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    private float _speed = 2.5f;
    void Update()
    {
        transform.Translate(_speed  * new Vector2(0, -1) * Time.deltaTime, Space.World);
    }
}
