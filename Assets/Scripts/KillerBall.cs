using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBall : MonoBehaviour
{
    public float thrust = 500;
    public float velocityDecrease;                //Esta variable hace que cuando se coje el power up la velocidad sea igual a este porcentaje
    public float speedMultiplier = 1; 
    public float speedAugmentor = 0.1f;


    public float maxSpeed;

    private Rigidbody2D myRigidbody2D;

    public Vector2 ballInitialForce;

    private Vector3 initialPosition;

    public bool speedUp = false;
    public bool sizeUp = false;
    Vector3 originalScale;
    public float scale;

    void Start ()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        initialPosition = this.transform.position;
        originalScale = this.transform.localScale;
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
            speedMultiplier = 1;
            myRigidbody2D.velocity *= velocityDecrease/100 ;
            speedUp = false;
        }
        if (sizeUp)
        {
            this.transform.localScale = originalScale * scale;
            sizeUp = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            collision.transform.GetComponent<Player>().Die();

            speedMultiplier += speedAugmentor;
            myRigidbody2D.AddForce(myRigidbody2D.velocity * speedMultiplier);
        }

        if ((myRigidbody2D.velocity.x < maxSpeed && myRigidbody2D.velocity.x > -maxSpeed) && ( myRigidbody2D.velocity.y < maxSpeed && myRigidbody2D.velocity.y > -maxSpeed))
        {
            speedMultiplier += speedAugmentor;
            myRigidbody2D.AddForce(myRigidbody2D.velocity * speedMultiplier);
        }
    }
}
