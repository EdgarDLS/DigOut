using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    public int levelToLoad;

    private float numberKeys = 3;
    private float keysPicked = 0;

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
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
    }
}
