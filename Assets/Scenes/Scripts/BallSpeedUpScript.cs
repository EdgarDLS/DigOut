using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeedUpScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            for (int n = 0; n < LevelGenerator.levelGenerator.killerBalls.Length; n++)
                LevelGenerator.levelGenerator.killerBalls[n].transform.GetComponent<KillerBall>().speedUp = true;
            Destroy(this.gameObject);
        }

    }
}
