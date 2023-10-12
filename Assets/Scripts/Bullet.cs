
using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float timer = 0;
    public float speed;
    public Rigidbody2D rigidBody2D;
    public float lifespan = 5;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (lifespan<timer)
        {
           Destroy(gameObject);
        }

    }
    public void SetVelocity(Vector2 direction) 
    {
        rigidBody2D.velocity = direction * speed;
    
    
    
    
    }



    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name.Equals("Zombie"))
        {
            Debug.Log("Killed Zombie");
            Destroy(other.gameObject);
        }

       
    }
}


