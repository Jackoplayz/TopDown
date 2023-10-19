using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Zombie : MonoBehaviour
{
    public int damage;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
   
    
    }


    public void TakeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Equals("Player2D"))
        {

            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
            
        }
    }






}

