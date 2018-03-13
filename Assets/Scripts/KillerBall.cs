using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBall : MonoBehaviour
{
    public float thrust = 500;

    public float speedMultiplier = 1;

    private Rigidbody2D myRigidbody2D;

    public Vector2 ballInitialForce;

    void Start ()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        myRigidbody2D.AddForce(ballInitialForce * speedMultiplier);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            myRigidbody2D.velocity = new Vector2(0, 0);

            collision.transform.GetComponent<Player>().Die();
        }

        if ((myRigidbody2D.velocity.x < 18 && myRigidbody2D.velocity.x > -18) && ( myRigidbody2D.velocity.y < 18 && myRigidbody2D.velocity.y > -18))
        {
            speedMultiplier += 0.1f;
            myRigidbody2D.AddForce(myRigidbody2D.velocity * speedMultiplier);
            Debug.Log(myRigidbody2D.velocity);
        }
    }
}
