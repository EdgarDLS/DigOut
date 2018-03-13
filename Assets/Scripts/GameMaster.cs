using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    public float numberKeys = 3;
    public float keysPicked = 0;

    private void Start()
    {
        if (GM != null)
            GameObject.Destroy(GM);
        else
            GM = this;
    }

    public void AddKey()
    {
        keysPicked++;

        if (keysPicked >= numberKeys)
        {
            Door.door.doorOpened = true;
        }
    }

    public void LoadNextLevel()
    {

    }
}
