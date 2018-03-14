using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedUpScript : MonoBehaviour {
    public float factor;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            collision.transform.GetComponent<Player>().speed *= factor;
            Destroy(this.gameObject);
        }

    }
}
