using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSiceUpScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            Drill.drill.makeBig = true;
            Destroy(this.gameObject);
        }

    }
}
