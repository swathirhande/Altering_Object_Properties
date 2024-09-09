
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    public string lavaFloorTag = "LavaFloor";
    public string secondPlankTag = "Plate2";
    public Transform Plate2;
    private bool shouldStop = false;
    public Color collisionColor = Color.green; // Color to change to upon collision

    private Renderer ballRenderer; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballRenderer = GetComponent<Renderer>(); 
    }

    void Update()
    {
        if (!shouldStop)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            if (moveHorizontal != 0 || moveVertical != 0)
            {
                Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f) * speed;
                rb.AddForce(movement);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(lavaFloorTag))
        {
            HandleLavaCollision();
        }

        if (collision.gameObject.CompareTag(secondPlankTag))
        {
            shouldStop = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        
        if (collision.gameObject.CompareTag("RotatingSquare")) 
        {
            ChangeColor();
        }
    }

    void HandleLavaCollision()
    {
        gameObject.SetActive(false);
    }

    void ChangeColor()
    {
        if (ballRenderer != null)
        {
            ballRenderer.material.color = collisionColor; 
        }
    }
}






