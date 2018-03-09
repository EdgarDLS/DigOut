using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D myRigidbody2D;

    void Start ()
    {
        myRigidbody2D = this.GetComponent<Rigidbody2D>();

        myRigidbody2D.freezeRotation = true;
        myRigidbody2D.gravityScale = 0;
	}

    void FixedUpdate ()
    {
        // Movement
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        movementInput *= speed;

        myRigidbody2D.velocity = movementInput * Time.deltaTime;
    }

    void Update()
    {

    }
}
