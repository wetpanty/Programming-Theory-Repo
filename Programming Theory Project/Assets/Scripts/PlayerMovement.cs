using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;
    public float speed = 10;
    //public float jumpForce = 15;
    public float torque = 5;
    public float brake = 5;
    public float turnSpeed = 5;
    public float gravityModifier = 1;
    //private bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        //MotorJump();
    }

    private void FixedUpdate()
    {
        MotorMove();
        MotorTurn();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Determine whether it is Obstacle
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Endline"))
        {
            Debug.Log("Victory");
        }
        else if(other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
        
    }

    void MotorTurn()
    {
        //playerRb.AddTorque(Vector3.up * torque * horizontalInput);
        playerRb.AddForce(Vector3.right * horizontalInput * turnSpeed * Time.deltaTime, ForceMode.VelocityChange);

    }

    

    void MotorMove()
    {
        playerRb.AddForce(Vector3.forward * speed * verticalInput * Time.deltaTime, ForceMode.VelocityChange);
    }

    

    //void MotorJump()
    //{
    //if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
    //{
    //   playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //  isOnGround = false;
    //}
    // }
}
