
using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour

{
    public float speed;
    public Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newCameraPosition = new Vector3(transform.position.x, transform.position.y, -5);

        Camera.main.transform.position = newCameraPosition;
    }

    private void FixedUpdate()
    {                     
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 look = new Vector3(ray.origin.x, ray.origin.y, 0);          

        Vector3 relativePos = look - transform.position;

        float angle = Vector3.SignedAngle(relativePos, Vector3.down, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, -angle);

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            // rigidBody.AddForce(Vector3.right * speed);
            moveDirection += Vector3.right * speed;           
        }

        if (Input.GetKey(KeyCode.A))
        {
            //  rigidBody.AddForce(Vector3.left * speed);
            moveDirection += Vector3.left * speed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            //  rigidBody.AddForce(Vector3.up * speed);
            moveDirection += Vector3.up * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //  rigidBody.AddForce(Vector3.down * speed);
            moveDirection += Vector3.down * speed;
        }

        rigidBody.velocity = moveDirection;
    }
}
