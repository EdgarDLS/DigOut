using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillUpScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            Drill.drill.makeBig = true;
            collision.GetComponent<Player>().drillUp = true;
            Destroy(this.gameObject);
        }
    }
}
