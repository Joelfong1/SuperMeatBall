using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagePlayer : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
