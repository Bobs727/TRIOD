using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    
    private void FixedUpdate()
    {
       transform.Translate(_speed*new Vector2(0, 1)*Time.deltaTime, Space.World); 
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Comet"))
        {
            Destroy(coll.gameObject);
            Destroy(GetComponent<GameObject>());
        }
    
        if (coll.gameObject.CompareTag("Walls") || coll.gameObject.CompareTag("Window"))
        {
            Destroy(gameObject);
        }
    }

    
}
