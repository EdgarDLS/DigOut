<<<<<<< Updated upstream:Assets/Scripts/GameMaster.cs
﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    public int levelToLoad;

    private bool levelCompleted = false;

    private float numberKeys = 3;
    private float keysPicked = 0;

    [HideInInspector]
    public int deathsCounter = 0;

    public Text keyText;
    public GameObject endStats;
    public Text youDiedText;

    private void Awake()
    {
        if (GM != null)
            GameObject.Destroy(GM);
        else
            GM = this;

        endStats = GameObject.Find("EndStats");
        keyText = GameObject.Find("KeyText").GetComponent<Text>();
        youDiedText = GameObject.Find("YouDiedText").GetComponent<Text>();

        keyText.text = "0/" + numberKeys.ToString();

        endStats.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && levelCompleted)
        {
            LoadNextLevel(levelToLoad);
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            LoadNextLevel(1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            LoadNextLevel(2);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            LoadNextLevel(3);
        }
    }

    public void AddKey()
    {
        keysPicked++;

        keyText.text = keysPicked.ToString() + "/" + numberKeys.ToString();

        if (keysPicked >= numberKeys)
        {
            keyText.color = Color.yellow;
            Door.door.doorOpened = true;
        }
    }

    public void LoadStats()
    {
        endStats.SetActive(true);

        keyText.text = "This level costed you " + deathsCounter.ToString() + " lives";

        levelCompleted = true;
    }

    public void LoadNextLevel(int level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
}
=======
﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    public int levelToLoad;

    private float numberKeys = 3;
    private float keysPicked = 0;

    public Text keyText;
    public GameObject fadeIn;
    public GameObject fadeOut;

    private void Start()
    {
        if (GM != null)
            GameObject.Destroy(GM);
        else
            GM = this;

        fadeIn = GameObject.Find("FadeIn");
        fadeOut = GameObject.Find("FadeOut");
        keyText = GameObject.Find("KeyText").GetComponent<Text>();

        keyText.text = "0/" + numberKeys.ToString();
    }

    public void AddKey()
    {
        keysPicked++;

        keyText.text = keysPicked.ToString() + "/" + numberKeys.ToString();

        if (keysPicked >= numberKeys)
        {
            keyText.color = Color.yellow;
            Door.door.doorOpened = true;
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
    }
}
>>>>>>> Stashed changes:Assets/Scenes/Scripts/GameMaster.cs
