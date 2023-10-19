
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
    public int damage;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag.Equals("Zombie"))
        {

            Zombie zombie = collision.gameObject.GetComponent<Zombie>();
            zombie.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
  
}


