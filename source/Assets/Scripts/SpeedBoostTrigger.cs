using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostTrigger : MonoBehaviour {

	public float speedAmount;
	public float turnSpeedAmount;
	public float durationInSeconds;

	private GameObject player;
	private PlayerController pc;
	private AudioSource audioData;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		pc = player.GetComponent<PlayerController> ();
		audioData = GetComponent<AudioSource> ();
	}

	IEnumerator RunEnum ()
	{
		yield return new WaitForSeconds(durationInSeconds);
		pc.forwardSpeed -= speedAmount;
		pc.turnSpeed -= turnSpeedAmount;
	}
		
	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			pc.forwardSpeed += speedAmount;
			pc.turnSpeed += turnSpeedAmount;
			StartCoroutine(RunEnum());
			audioData.Play (0);
		}
	}
}
