using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Window : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _sprites; 

    private int _speed = 2;

    public int nSpriteNow = 0;

    private void Start()
    {
        SetRandomColor();
    }

    private void FixedUpdate() {
        transform.Translate(_speed * new Vector2(0, -1) * Time.deltaTime, Space.World);
    }

    public void SetRandomColor()
    {
        nSpriteNow = Random.Range(0, 3); 
        GetComponent<SpriteRenderer>().sprite = _sprites[nSpriteNow];
    }
}
