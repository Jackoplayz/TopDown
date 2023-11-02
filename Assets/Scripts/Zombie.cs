using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Zombie : MonoBehaviour
{
    public int damage;
    public float health;
    public Player player;
    public Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player2D").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();    
    }

    void FollowPlayer()
    {
        if (player.health <= 0) return;

        Vector3 lookDirection = player.transform.position - transform.position;
        lookDirection.z = 0;
        lookDirection = lookDirection.normalized;

        float angle = Vector3.SignedAngle(lookDirection, Vector3.down, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, -angle);

        rigidBody2D.velocity = lookDirection;
    }


    public void TakeDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject ControllerObject = GameObject.Find("GameController");
            GameController Controller = ControllerObject.GetComponent<GameController>();
            Controller.zombieCounter = Controller.zombieCounter - 1;
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
