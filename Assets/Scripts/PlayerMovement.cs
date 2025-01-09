using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] float speed = 10;
    [SerializeField] float jumpForce = 5;
    [SerializeField] bool isGrounded;
    
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();

    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

         // Horizontal movement
        myRB.AddForce(Vector2.right * horizontalInput * speed , ForceMode2D.Force);

       

        if(Input.GetKey(KeyCode.W) && isGrounded)
        {

            myRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Platform"))
        {
            
            isGrounded = true;

        }

    }

     void OnTriggerExit2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("Platform"))
        {

            isGrounded = false;

        }

    }


}
