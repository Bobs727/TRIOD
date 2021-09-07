using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public GameObject triangle; 

    [SerializeField] private GameObject scoreLabel; 

    [SerializeField] private Sprite[] _sprites; 

    private int _nSpriteNow = 0;
    private int _score = 0;
    
    private const float Speed = 7.5f;
    private const float DoubleClickTime = 0.35f;
    private float _lastClickTime = 0;
    
    private bool _isRightButtonPressedLast;

    private Vector2 _direction;
    private SpriteRenderer _cachedSpiteRenderer;
    private Text _textObj;
    
    private void Start()
    {
        _cachedSpiteRenderer = triangle.GetComponent<SpriteRenderer>();
        _textObj = scoreLabel.GetComponent<Text>();
        
        _direction = new Vector2(0f, 0f);

        _nSpriteNow = Random.Range(0, 2);
        ChangeColor();
        
    }
    
    private void FixedUpdate()
    {
        triangle.transform.Translate(_direction * Speed * Time.deltaTime, Space.World);
    }

    private void ChangeColor()
    {
        _nSpriteNow++;
        if (_nSpriteNow > 2)
            _nSpriteNow = 0; 
        _cachedSpiteRenderer.sprite = _sprites[_nSpriteNow];
    }

    private bool CheckDoubleClick()
    {
        if ((Time.time - _lastClickTime) > DoubleClickTime)
        {
            _lastClickTime = Time.time;
            return false;
        }
        else
        {
            _lastClickTime = Time.time;
            return true;
        }
    }

    public void OnButtonClick(bool isRightButtonPressed)
    {
        if (isRightButtonPressed)
        {
            if (_isRightButtonPressedLast && CheckDoubleClick())
            {
                ChangeColor();
            }

            _direction = Vector2.right;
            _isRightButtonPressedLast = true;
        }
        else
        {   
            if (!_isRightButtonPressedLast && CheckDoubleClick())
            {
                ChangeColor();
            }

            _direction = Vector2.left;
            _isRightButtonPressedLast = false;
        }
    }

    private void GameOver()
    {
        Destroy(this.gameObject);
        FindObjectOfType<GameManager>().GameOver();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Window"))
        {
            
            var obj = coll.GetComponent<Window>();
            if (obj.nSpriteNow == _nSpriteNow){
                _score += 1;
                _textObj.text = _score.ToString();
            }
            else
            {
                GameOver();
            }
        }  
         if(coll.gameObject.CompareTag("Comet"))
            {
                GameOver();
            }        
        else{
            if (coll.gameObject.CompareTag("Walls"))
            {
                GameOver();
            }
        }
    }
    
}
