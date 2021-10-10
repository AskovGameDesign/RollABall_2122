using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public LayerMask groundLayer;
    public float groundCheckLength = 0.55f;
    public float jumpForce = 100f;

    float horizontalMovement;
    float verticalMovement;
    Rigidbody rigidbody;
    Vector3 movement;
    bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
        movement = new Vector3(horizontalMovement, 0, verticalMovement).normalized;

        // kode der tjekker om vi er tæt på jorden
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckLength, groundLayer);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(movement * speed);
    }

}
