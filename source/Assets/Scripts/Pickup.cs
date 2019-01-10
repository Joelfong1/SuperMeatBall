using System.Collections;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int value;
	private AudioSource audioData;

	void Start ()
	{
		audioData = GetComponent<AudioSource> ();
	}

	IEnumerator RunEnum ()
	{
		audioData.Play (0);
		yield return new WaitForSeconds(0.8f);
		FindObjectOfType<GameManager>().AddScore(value);
		Destroy(gameObject);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
			StartCoroutine(RunEnum());
        }
    }

}
