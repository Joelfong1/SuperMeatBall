using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public Text stageScore;

    void Start()
    {
        Invoke("DisplayScore", 0f);
    }

    //Switches to the next scene in the build order
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneIndex") + 1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastLevelLoaded"));
    }

    public void Home()
    {
        SceneManager.LoadScene("Title");
    }

    private void DisplayScore()
    {
        if (PlayerPrefs.GetInt("PickupsInLevel") == 0)
        {
            stageScore.text = "";
        } else
            stageScore.text = "Score: " + PlayerPrefs.GetInt("CurrentScore") + "/" + (PlayerPrefs.GetInt("PickupsInLevel") + PlayerPrefs.GetInt("CurrentScore"));
    }
}
