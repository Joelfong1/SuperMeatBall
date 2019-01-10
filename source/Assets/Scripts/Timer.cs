using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timer;

    void Start()
    {
        InvokeRepeating("ReduceTime", 1, 1);
    }

    void ReduceTime()
    {
        int currentTime = int.Parse(timer.text) - 1;
        timer.text = currentTime.ToString();

        if (currentTime == 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
