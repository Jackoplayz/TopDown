using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Zombie : MonoBehaviour
{
    public GameController gameController;
    public float speed;
    public float minSpeed, maxSpeed;
    public int damage;
    public float health;
    public int minHealth, maxHealth;
    public int minDamage, maxDamage;
    public Player player;
    public Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        damage = Random.Range(minDamage, maxDamage);
        health = Random.Range(minHealth, maxHealth);
        player = GameObject.Find("Player2D").GetComponent<Player>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.gameRunning)
        {
            rigidBody2D.velocity = Vector2.zero;
            return;
        }
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

        rigidBody2D.velocity = lookDirection * speed;
    }


    public void TakeDamage(float damage)
    {
        //Check zombies health before applying damage, if it's already dead, then return
        if (health <= 0) return;

        health = health - damage;
        if (health <= 0)
        {

           
            GameObject ControllerObject = GameObject.Find("GameController");
            GameController Controller = ControllerObject.GetComponent<GameController>();
            
            Controller.KillZombie(gameObject);
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
