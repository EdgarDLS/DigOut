using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
 

public class Player : MonoBehaviour
{
    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    };

    public VirtualJoystick moveJoystick;
    public VirtualDigButton drillButton;
    //private Vector2 movementInput = Vector2.zero;

    public GameObject drillZone;
    public GameObject drill;
    public ParticleSystem deathEffect;  
    public bool drillUp = false;        // Bigger drill

    [Space]
    Direction facingDirection = Direction.LEFT; // Direction the player will be facing
    public float speed = 100;
    public float drillingSpeed = 0.5f;
    public float drillDistance = 0.55f;

    private bool drilling = false;
    private bool drillingTime = false;
    private bool movement = true;

    private float moveTimeCurrent = 0;
    private float moveTimeTotal = 0;

    private Rigidbody2D myRigidbody2D;


    // Drill rotation values
    [SerializeField] float rotationLerpTime = 0.2f;
    float currentRotationLerpTime;

    Vector2 actualDrillPosition = new Vector2(0, 0);
    Vector2 desiredDrillPosition;

    Vector3 actualDrillRotation = new Vector3(0, 0, 0);
    Vector3 desiredDrillRotation;

    bool lerpValues = false;



    //Cosas de Albert ;)
   

    void Start ()
    {
        myRigidbody2D = this.GetComponent<Rigidbody2D>();

        myRigidbody2D.freezeRotation = true;
        myRigidbody2D.gravityScale = 0;

        moveJoystick = GameObject.Find("VirtualJoystickContainer").GetComponent<VirtualJoystick>();
        drillButton = GameObject.Find("VirtualDrillButton").GetComponent<VirtualDigButton>();
    }

    void FixedUpdate ()
    {
        // Movement
        if (movement && !drillingTime)
        {
            //movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            float x = moveJoystick.InputDirection.x;
            float y = moveJoystick.InputDirection.z;


            Vector2 movementInput = CheckDirection(x, y);

            Debug.Log(movementInput);

            movementInput *= speed;

            myRigidbody2D.velocity = movementInput * Time.deltaTime;
        }

        // Drill Movement
        if (drillingTime)
        {
            drill.SetActive(true);

            Vector2 drillingDirection = new Vector2 (0, 0);

            switch (facingDirection)
            {
                case Direction.LEFT:
                    drillingDirection = new Vector2(-1, 0);

                    break;

                case Direction.RIGHT:
                    drillingDirection = new Vector2(1, 0);

                    break;

                case Direction.UP:
                    drillingDirection = new Vector2(0, 1);

                    break;

                case Direction.DOWN:
                    drillingDirection = new Vector2(0, -1);

                    break;

            }

            Vector2 movementInput = new Vector2(drillingDirection.x, drillingDirection.y).normalized;
            movementInput *= (speed * drillingSpeed);

            myRigidbody2D.velocity = movementInput * Time.deltaTime;
        }

        //    if (moveTimeCurrent < moveTimeTotal)
        //    {
        //        moveTimeCurrent += Time.deltaTime;

        //        drill.transform.position = Vector3.Lerp(drill.transform.position, drillZone.transform.position, moveTimeCurrent / moveTimeTotal);
        //    }
        //    else
        //    {
        //        drill.transform.localPosition = new Vector2(0, 0);
        //        drill.SetActive(false);

        //        movement = true;
        //        drillingTime = false;
        //    }
        //}
    }

    void Update()
    {
        //if (drillUp)
        //{
        //    drillZone.transform.localScale *= 6;
        //    drillUp = false;
        //}


//#if UNITY_STANDALONE || UNITY_WEBPLAYER

        //if (moveJoystick.InputDirection != Vector3.zero)
        //{
        //    float x = moveJoystick.InputDirection.x;
        //    float y = moveJoystick.InputDirection.z;

        //    if (x >= 0.5f)
        //    {
        //        x = 1;
        //        y = 0;
        //    }
        //    else if(x < 0.5f)
        //    {
        //        x = -1;
        //        y = 0;
        //    }
        //    else if (y >= 0.5f)
        //    {
        //        x = 0;
        //        y = 1;
        //    }
        //    else
        //    {
        //        x = 0;
        //        y = -1;
        //    }

        //    movementInput = new Vector2(x, y).normalized;
        //}

        //else
        //{
        //    movementInput = Vector2.zero;
        //}

        //Debug.Log(movementInput);


        // Drilling key
        if (drillButton.drillOut)
        {
            //drill.SetActive(true);

            //moveTimeCurrent = 0;
            //moveTimeTotal = (drill.transform.position - drillZone.transform.position).magnitude / drillingSpeed;

            drillingTime = true;

            //myRigidbody2D.velocity = new Vector2(0, 0);
            //movement = false;

            //Drill.drill.makeSmall = true;
            if (drillZone.transform.localScale.x > 1)
            {
                drillZone.transform.localScale /= 6;
            }
        } 

        else
        {
            drill.SetActive(false);
            drillingTime = false;

            if (drillZone.transform.localScale.x > 1)
            {
                drillZone.transform.localScale /= 6;
            }
        }

        LerpDrill();

//#else
//        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
//        {
//            drill.transform.eulerAngles = new Vector3(0, 0, 180f);
//            drillZone.transform.localPosition = new Vector2(-drillDistance, -0);

//            facingDirection = Direction.LEFT;
//        }
    }

    private Vector2 CheckDirection(float _x, float _y)
    {
        // Clmap values for the joystick
        if (_x > 0.4f || _x < -0.4f)
            _y = 0;

        else if (_y > 0.4f || _y < -0.4f)
            _x = 0;

        // Set direction
        if (_x < 0)     // LEFT
        {
            desiredDrillRotation = new Vector3(0, 0, 180f);

            actualDrillPosition = new Vector2(drillZone.transform.position.x, drillZone.transform.position.y);
            drillZone.transform.localPosition = new Vector2(-drillDistance, -0);
            desiredDrillPosition = new Vector2(drillZone.transform.position.x, drillZone.transform.position.y);


            facingDirection = Direction.LEFT;
            currentRotationLerpTime = 0;
            lerpValues = true;
        }

        else if(_x > 0) // RIGHT
        {
            desiredDrillRotation = new Vector3(0, 0, 0f);

            actualDrillPosition = new Vector2(drillZone.transform.position.x, drillZone.transform.position.y);
            drillZone.transform.localPosition = new Vector2(drillDistance, -0);
            desiredDrillPosition = new Vector2(drillZone.transform.position.x, drillZone.transform.position.y);


            facingDirection = Direction.RIGHT;

            currentRotationLerpTime = 0;
            lerpValues = true;
        }
        
        else if(_y < 0) // DOWN
        {
            desiredDrillRotation = new Vector3(0, 0, -90f);

            actualDrillPosition = new Vector2(drillZone.transform.position.x, drillZone.transform.position.y);
            drillZone.transform.localPosition = new Vector2(0, -drillDistance);
            desiredDrillPosition = new Vector2(drillZone.transform.position.x, drillZone.transform.position.y);


            facingDirection = Direction.DOWN;

            currentRotationLerpTime = 0;
            lerpValues = true;
        }

        else if(_y > 0) // UP
        {
            desiredDrillRotation = new Vector3(0, 0, 90f);

            actualDrillPosition = new Vector2(drillZone.transform.position.x, drillZone.transform.position.y);
            drillZone.transform.localPosition = new Vector2(0, drillDistance);
            desiredDrillPosition = new Vector2(drillZone.transform.position.x, drillZone.transform.position.y);


            facingDirection = Direction.UP;

            currentRotationLerpTime = 0;
            lerpValues = true;
        }


        return new Vector2(_x, _y);
    }

    private void LerpDrill()
    {
        if (lerpValues)
        {
            currentRotationLerpTime += Time.deltaTime;

            if (currentRotationLerpTime > rotationLerpTime)
            {
                currentRotationLerpTime = rotationLerpTime;
                actualDrillRotation = desiredDrillRotation; // Rotation
                actualDrillPosition = desiredDrillPosition; // Position

                lerpValues = false;
            }

            float percent = currentRotationLerpTime / rotationLerpTime;

            drill.transform.eulerAngles = Vector3.Lerp(actualDrillRotation, desiredDrillRotation, percent);
            drill.transform.position = Vector2.Lerp(actualDrillPosition, desiredDrillPosition, percent);
        } 
    }

    public void Die()
    {

        Destroy(this.gameObject);
        Destroy(Instantiate(deathEffect.gameObject, transform.position, transform.rotation) as GameObject, 2.5f);

        GameMaster.GM.deathsCounter++;

        CameraShake.CS.shakeDuration = 1;

        LevelGenerator.levelGenerator.playerDead = true;
    }
}