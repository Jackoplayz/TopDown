
using System;
using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public GameController gameController;
    public float speed;
    public float sprintMultiplier;
    public float bulletSpawnOffset = 0.3f;
    public Rigidbody2D rigidBody2D;
    public GameObject bulletPrefab;
    public int health;
    public SpriteRenderer spriteRenderer;
    public UIController UI;
    public Pistol pistol;
    public Rifle rifle;
    public Shotgun shotgun;
    List<Weapon> weapons = new List<Weapon>();
    Weapon selectedWeapon;
    int selectedWeaponIndex;
    // Start is called before the first frame update
    void Start()
    {
        weapons.Add(pistol);
        weapons.Add(rifle);
        weapons.Add(shotgun);
        selectedWeaponIndex = 0;
        selectedWeapon = weapons[selectedWeaponIndex];
        UI.SetSelectedWeapon(selectedWeaponIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.gameRunning)
        {
            rigidBody2D.velocity = Vector2.zero;
            return;
        }
        if (Input.GetAxis("Mouse ScrollWheel") >0)
            {
                if (selectedWeaponIndex == weapons.Count -1)
                {
                    selectedWeaponIndex = 0;
                }
                else
                {
                    selectedWeaponIndex++;
                }
                selectedWeapon = weapons[selectedWeaponIndex];
                             UI.SetSelectedWeapon(selectedWeaponIndex);
            }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeaponIndex == 0)
            {
                selectedWeaponIndex = weapons.Count - 1;
            }
            else
            {
                selectedWeaponIndex--;
            }
            selectedWeapon = weapons[selectedWeaponIndex];
            UI.SetSelectedWeapon(selectedWeaponIndex);
        }



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
        if (!gameController.gameRunning)
        {
            rigidBody2D.velocity = Vector2.zero;
            return;
        }
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

