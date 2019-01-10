using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int currentScore;
    public Text scoreText;
	public Transform meatballEndPlatePrefab;

    private string currentScene;
    private GameObject[] pickupsArr;
    private int pickupsCount;
    private int currentSceneIndex;
	private AudioSource audioData;

    // Use this for initialization
    void Start ()
    {
		audioData = GetComponent<AudioSource> ();
        currentScore = 0;
        pickupsCount = 0;
        currentSceneIndex = 0;
        PlayerPrefs.SetInt("PickupsInLevel", pickupsCount);
        PlayerPrefs.SetString("LastLevelLoaded", null);
        PlayerPrefs.SetInt("SceneIndex", currentSceneIndex);
        Invoke("GetInfo", 0f);
    }

	private void AddMeatballToPlate()
	{
		Vector3 spawnLocation = GameObject.Find("GoalPlate").transform.position;
		spawnLocation.y += 1.0f;
		spawnLocation.x += Random.Range (-1.330f, 1.330f);
		spawnLocation.z += Random.Range (-1.330f, 1.330f);
		Instantiate (meatballEndPlatePrefab, spawnLocation, Quaternion.identity);
	}

    public void AddScore(int score)
    {
        currentScore += score;
		AddMeatballToPlate ();
        scoreText.text = "Score: " + currentScore;
    }

    public void CompleteLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level50Kenny's")
        {
            Invoke("End", 2f);
        }
        else
        {
            PlayerPrefs.SetInt("CurrentScore", currentScore);
            Invoke("Next", 2f);
        }
    }

    public void GameOver()
    {
		audioData.Play (0);
        FindObjectOfType<PlayerManager>().RespawnEffect();
        Invoke("Floored", 2f);
    }

    private void Floored()
    {
        Invoke("GetInfo", 0f);
        SceneManager.LoadScene("Floored");
    }

    private void Next()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Invoke("GetInfo", 0f);
        SceneManager.LoadScene("StageComplete");
    }

    private void End()
    {
        SceneManager.LoadScene("EndScreen");
    }

    private void GetInfo()
    {
        //Getting scene name for screen transfers
        if (SceneManager.GetActiveScene().name != currentScene)
        {
            currentScene = SceneManager.GetActiveScene().name;
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SceneIndex", currentSceneIndex);
            PlayerPrefs.SetString("LastLevelLoaded", currentScene);
        }

        //Getting number of pickups for complete screen
        pickupsArr = GameObject.FindGameObjectsWithTag("Pickup");
        pickupsCount = pickupsArr.Length;
        PlayerPrefs.SetInt("PickupsInLevel", pickupsCount);
        
    }
}
