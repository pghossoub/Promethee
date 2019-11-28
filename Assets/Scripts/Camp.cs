using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camp : MonoBehaviour {

	public GameObject player;
	public GameObject campPanel;
	public GameObject nightCampPanel;
	public GameObject gameOverPanel;
	public Button useFoodWaterButton;
	public Button useFoodButton;
	public Button useWaterButton;
	public Button useNothingButton;
	public GameObject nextButton;

	private GameManager gameManager;
	private Player playerScript;
	private GameOver gameOver;
	private bool death = false;


	public void OpenCampPanel()
	{
		if (gameManager == null)
			gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		

		if (!gameManager.movementOn && !gameManager.windowOpened) {
			
			gameManager.windowOpened = true;

			playerScript = player.GetComponent<Player> ();

			if (playerScript.water > 0 && playerScript.food > 0) {
				useFoodWaterButton.interactable = true;
				useFoodButton.interactable = true;
				useWaterButton.interactable = true;
			} else if (playerScript.water > 0)
				useWaterButton.interactable = true;
			else if (playerScript.food > 0)
				useFoodButton.interactable = true;
		

			gameOver = gameOverPanel.GetComponent<GameOver> ();
			campPanel.SetActive (true);
		}
	}

	public void UseFoodWater()
	{
		playerScript.ManageWater (-1);
		playerScript.ManageFood (-1);
		playerScript.GainWill (20);
		playerScript.GainHealth (20);
		playerScript.ManageEnergy (playerScript.maxEnergy);
		OpenNightCampPanel ();
	}

	public void UseOnlyFood()
	{
		playerScript.ManageFood (-1);
		playerScript.GainWill (10);
		death = playerScript.LoseHealth (10);
		if (death)
			gameOver.GameOverDisplay ("dehydration");
		else {
			playerScript.ManageEnergy (playerScript.maxEnergy / 2);
			OpenNightCampPanel ();
		}
	}

	public void UseOnlyWater()
	{
		playerScript.ManageWater (-1);
		playerScript.GainHealth (10);
		death = playerScript.LoseWill (10);
		if (death)
			gameOver.GameOverDisplay ("starvation");
		else {
			playerScript.ManageEnergy (playerScript.maxEnergy / 2);
			OpenNightCampPanel ();
		}
	}

	public void UseNothing()
	{
		death = playerScript.LoseHealth (10);
		if (death)
			gameOver.GameOverDisplay ("dehydration");
		else {
			death = playerScript.LoseWill (10);
			if (death)
				gameOver.GameOverDisplay ("starvation");
			else
				playerScript.ManageEnergy (playerScript.maxEnergy/2);
				OpenNightCampPanel();
		}
	}

	void OpenNightCampPanel()
	{
		useFoodWaterButton.interactable = false;
		useFoodButton.interactable = false;
		useWaterButton.interactable = false;
		nightCampPanel.SetActive (true);
		nightCampPanel.GetComponent<AudioSource> ().Play ();
		StartCoroutine (WaitNight ());

	}

	IEnumerator WaitNight()
	{
		yield return new WaitForSeconds (4.7f);
		nextButton.SetActive (true);
	}

	public void CloseCampPanel()
	{
		gameManager.windowOpened = false;
		campPanel.SetActive (false);
		nightCampPanel.SetActive (false);
	}
}
