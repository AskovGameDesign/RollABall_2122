using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;

    float horizontalMovement;
    float verticalMovement;
    Rigidbody rigidbody;
    Vector3 movement;

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
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(movement * speed);
    }

}
