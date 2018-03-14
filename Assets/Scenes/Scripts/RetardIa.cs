using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetardIa : MonoBehaviour {
    public float velocity;
    public Vector3 speed;
    int direction;
	// Use this for initialization
	void Start () {
        this.transform.rotation = new Quaternion(0,0, 0, 0);
        direction = (int)Random.Range(0, 3);
        switch (direction){
            case 0:
                speed = new Vector3(0, 1, 0);
                break;
            case 1:
                speed = new Vector3(0, -1, 0);
                break;
            case 2:
                speed = new Vector3(1, 0, 0);
                break;
            case 3:
                speed = new Vector3(-1, 0, 0);
                break;
            default:
                speed = new Vector3(1, 0, 0);
                break;
        }

    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position += speed * velocity;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.transform.position += speed * -velocity * 0.9f;
        direction = (int)Random.Range(0, 3.999999f);
        switch (direction)
        {
            case 0:
                speed = new Vector3(0, 1, 0);
                break;
            case 1:
                speed = new Vector3(0, -1, 0);
                break;
            case 2:
                speed = new Vector3(1, 0, 0);
                break;
            case 3:
                speed = new Vector3(-1, 0, 0);
                break;
            default:
                speed = new Vector3(1, 0, 0);
                break;
        }
    }
}
