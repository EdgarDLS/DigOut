using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]


public class Player : MonoBehaviour
{
    public GameObject drillZone;
    public GameObject drill;
    public ParticleSystem deathEffect;

    [Space]
    public float speed = 100;
    public float drillingSpeed = 0.2f;

    private bool drilling = false;
    private bool drillingTime = false;
    private bool movement = true;

    private float moveTimeCurrent = 0;
    private float moveTimeTotal = 0;

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
        if (movement)
        {
            Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            movementInput *= speed;

            myRigidbody2D.velocity = movementInput * Time.deltaTime;
        }
    }

    void Update()
    {
       if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))  && !drillingTime)
        {
            drill.transform.eulerAngles = new Vector3(0, 0, 180f);
            drillZone.transform.localPosition = new Vector2(-0.45f, -0);
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))  && !drillingTime)
        {
            drill.transform.eulerAngles = new Vector3(0, 0, 0f);
            drillZone.transform.localPosition = new Vector2(0.45f, -0);
        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))  && !drillingTime)
        {
            drill.transform.eulerAngles = new Vector3(0, 0, 90f);
            drillZone.transform.localPosition = new Vector2(0, 0.45f);
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))  && !drillingTime)
        {
            drill.transform.eulerAngles = new Vector3(0, 0, -90f);
            drillZone.transform.localPosition = new Vector2(0, -0.45f);
        }

        else if ((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space)))
        {
            drill.SetActive(true);

            moveTimeCurrent = 0;
            moveTimeTotal = (drill.transform.position - drillZone.transform.position).magnitude / drillingSpeed;

            drillingTime = true;

            myRigidbody2D.velocity = new Vector2(0, 0);
            movement = false;

            //Drill.drill.makeSmall = true;
        }

        // Drill Movement
        if (drillingTime)
        {
            if (moveTimeCurrent < moveTimeTotal)
            {
                moveTimeCurrent += Time.deltaTime;

                drill.transform.position = Vector3.Lerp(drill.transform.position, drillZone.transform.position, moveTimeCurrent/moveTimeTotal);
            }
            else
            {
                drill.transform.localPosition = new Vector2(0, 0);
                drill.SetActive(false);

                movement = true;
                drillingTime = false;
            }
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
        Destroy(Instantiate(deathEffect.gameObject, transform.position, transform.rotation) as GameObject, 2.5f);

        GameMaster.GM.deathsCounter++;

        LevelGenerator.levelGenerator.playerDead = true;
    }
}