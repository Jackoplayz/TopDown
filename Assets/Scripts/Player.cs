
using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour

{
    public float speed;
    public float sprintMultiplier;
    public float bulletSpawnOffset = 0.3f;
    public Rigidbody2D rigidBody2D;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPosition = new Vector3(transform.position.x, transform.position.y, -5);

        Camera.main.transform.position = newCameraPosition;

        SetLookDirection();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnBullet();
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

    private void SpawnBullet()
    {      
        //Get the direction of the mouse click
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 lookDirection = ray.origin - transform.position;
        lookDirection.z = 0;
        //Normalize sets vector magnitude (the length) to 1
        lookDirection = lookDirection.normalized;


        Vector3 spawnPostion = transform.position + (bulletSpawnOffset * lookDirection);

        var bulletInstance = Instantiate(bulletPrefab, spawnPostion, Quaternion.identity);

        bulletInstance.GetComponent<Bullet>().SetVelocity(lookDirection);

        float angle = Vector3.SignedAngle(lookDirection, Vector3.down, Vector3.forward);
        bulletInstance.transform.rotation = Quaternion.Euler(0, 0, -angle);
    }
}
