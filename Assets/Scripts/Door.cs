using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door door;

    public bool doorOpened = false;

    private void Start()
    {
        if (door != null)
            GameObject.Destroy(door);
        else
            door = this;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (doorOpened)
        {
            if (collision.transform.tag.Equals("Player"))
            {
                //GameMaster.GM;
            }
        }
    }
}
