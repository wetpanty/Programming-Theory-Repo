using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private Rigidbody obstacleRb;
    private GameObject player;
    protected float backingSpeed = 20;
    public float speed
    {
        get => backingSpeed;
        set
        {
            if (value < 0f)
            {
                Debug.Log("Speed can not be set less than 0");
            }
            else
            {
                backingSpeed = value;
            }
        }
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        obstacleRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {

        MoveBackwards();
    }

    private void Update()
    {
        if (transform.position.z < -5)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z > player.transform.position.z + 230 || transform.position.z < player.transform.position.z - 20)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void MoveBackwards()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

}
