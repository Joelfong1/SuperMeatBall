using System.Collections;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameManager gameManager;

	private AudioSource audioData;

	void Start ()
	{
		audioData = GetComponent<AudioSource> ();
	}

	IEnumerator RunEnum ()
	{
		audioData.Play (0);
		yield return new WaitForSeconds(0.8f);
		gameManager.CompleteLevel();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
			StartCoroutine(RunEnum());
        }
    }
}
