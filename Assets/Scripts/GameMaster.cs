using UnityEngine;
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
