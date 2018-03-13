using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public bool big = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.transform.tag.Equals("Block"))
        {
            Destroy(collision.gameObject);
        }
    }
}
