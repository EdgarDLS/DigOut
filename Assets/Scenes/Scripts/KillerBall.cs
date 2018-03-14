using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBall : MonoBehaviour
{
    public float thrust = 500;

    public float speedMultiplier = 1;
    public float speedAugmentor = 0.1f;

    public float maxSpeed;

    private Rigidbody2D myRigidbody2D;

    public Vector2 ballInitialForce;

    private Vector3 initialPosition;

    public bool speedUp = false;
    
    void Start ()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        initialPosition = this.transform.position;

        myRigidbody2D.AddForce(ballInitialForce * speedMultiplier);


    }

    public void ResetBall()
    {
        transform.position = initialPosition;
        myRigidbody2D.AddForce(ballInitialForce * speedMultiplier);
    }
    private void Update()
    {
        if (speedUp)
        {
            speedMultiplier -= speedAugmentor * 2;
            speedUp = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            myRigidbody2D.velocity = new Vector2(0, 0);
            speedMultiplier = 1;

            collision.transform.GetComponent<Player>().Die();
        }

        if ((myRigidbody2D.velocity.x < maxSpeed && myRigidbody2D.velocity.x > -maxSpeed) && ( myRigidbody2D.velocity.y < maxSpeed && myRigidbody2D.velocity.y > -maxSpeed))
        {
            speedMultiplier += speedAugmentor;
            myRigidbody2D.AddForce(myRigidbody2D.velocity * speedMultiplier);
        }
    }
}
