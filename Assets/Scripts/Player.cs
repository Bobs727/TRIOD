using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int speed;
    private int normalSpeed = 5;

    // Start is called before the first frame update
   public void Start()
    {
       
    }

    // Update is called once per frame
    public void Update()
    {
        
    }




public void OnRightButton ()
{
    Debug.Log("Right");
}

public void OnLeftButton ()
{
   Debug.Log("Left");
}
}