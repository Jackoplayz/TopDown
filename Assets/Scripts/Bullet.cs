
using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {




    }
    public void SetVelocity(Vector2 direction) 
    {
        rigidBody2D.velocity = direction * speed;
    
    
    
    
    }




}


