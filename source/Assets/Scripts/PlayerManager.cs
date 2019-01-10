using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
    public PlayerController player;

    private bool isRespawning;
    public float respawnLength;

    public Image blackScreen;
    private bool fadeFromBlack;
    private bool fadeToBlack;
    public float fadeTime;
    public float fadeWait;

	private bool isDead = false;
	
	// Update is called once per frame
	void Update () {

        if (player.transform.position.y <= -10f && !isDead)
        {
			isDead = true;
            FindObjectOfType<GameManager>().GameOver();
        }

        //Check if the player has died, and if the alpha transition needs to be made
        if (fadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeTime * Time.deltaTime));
            if (blackScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }
        //As above, but fade back in
        if (fadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeTime * Time.deltaTime));
            if (blackScreen.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
    }

    public void RespawnEffect()
    {
        if(!isRespawning)
        {
            StartCoroutine("RespawnRoutine");
        }
    }

    //Called coroutine for respawning, to help with fade and effect timing
    public IEnumerator RespawnRoutine()
    {
        isRespawning = true;
        
        yield return new WaitForSeconds(respawnLength);
        fadeToBlack = true;
        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(fadeWait);
        fadeToBlack = false;
        //fadeFromBlack = true;

        isRespawning = false;

        player.gameObject.SetActive(true);
    }
}
