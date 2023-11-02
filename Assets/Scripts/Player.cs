
using System;
using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float speed;
    public float sprintMultiplier;
    public float bulletSpawnOffset = 0.3f;
    public Rigidbody2D rigidBody2D;
    public GameObject bulletPrefab;
    public int health;
    public SpriteRenderer spriteRenderer;

    public Pistol pistol;
    public Rifle rifle;
    List<Weapon> weapons = new List<Weapon>();
    Weapon selectedWeapon;
    // Start is called before the first frame update
    void Start()
    {
        weapons.Add(pistol);
        weapons.Add(rifle);
        selectedWeapon = weapons[1];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPosition = new Vector3(transform.position.x, transform.position.y, -5);

        Camera.main.transform.position = newCameraPosition;

        SetLookDirection();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           selectedWeapon.Fire();
        }
    }

    private void FixedUpdate()
    {             
        Vector3 moveDirection = Vector3.zero;

        float sprint = 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = sprintMultiplier;
        }


        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;           
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.down;
        }

       rigidBody2D.velocity = moveDirection * speed * sprint;    
    }

    private void SetLookDirection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 lookDirection = ray.origin - transform.position;
        lookDirection.z = 0;

        float angle = Vector3.SignedAngle(lookDirection, Vector3.down, Vector3.forward);

        transform.rotation = Quaternion.Euler(0, 0, -angle);
    }  

    public void TakeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            spriteRenderer.enabled = false;
        }
}   }

