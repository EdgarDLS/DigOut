using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBall : MonoBehaviour
{
    public static KillerBall killerBall;

    public float thrust = 500;

    public float speedMultiplier = 1;
    public float speedAugmentor = 0.1f;

    public float maxSpeed;

    private Rigidbody2D myRigidbody2D;

    public Vector2 ballInitialForce;


    private void Awake()
    {
        if (killerBall != null)
            GameObject.Destroy(killerBall);
        else
            killerBall = this;
    }

    void Start ()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        myRigidbody2D.AddForce(ballInitialForce * speedMultiplier);
    }

    public void ResetBall()
    {
        transform.position = new Vector3(1.6f, -3.1f, -0.38f);
        myRigidbody2D.AddForce(ballInitialForce * speedMultiplier);
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
