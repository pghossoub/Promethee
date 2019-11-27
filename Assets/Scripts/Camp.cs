using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camp : MonoBehaviour {

	public GameObject player;
	public GameObject campPanel;
	public GameObject nightCampPanel;
	public Button useFoodWaterButton;
	public Button useFoodButton;
	public Button useWaterButton;
	public Button useNothingButton;
	public GameObject nextButton;

	private Player playerScript;
	private bool death = false;


	public void OpenCampPanel()
	{
		playerScript = player.GetComponent<Player> ();

		if (playerScript.water > 0 && playerScript.food > 0) {
			useFoodWaterButton.interactable = true;
			useFoodButton.interactable = true;
			useWaterButton.interactable = true;
		} 
		else if (playerScript.water > 0)
			useWaterButton.interactable = true;
		else if (playerScript.food > 0)
			useFoodButton.interactable = true;
		
		campPanel.SetActive (true);
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
		death = playerScript.LoseHealth (10);
		if (death)
			playerScript.GameOver();
		else
			playerScript.ManageEnergy (playerScript.maxEnergy/2);
			OpenNightCampPanel ();
	}

	public void UseOnlyWater()
	{
		playerScript.ManageWater (-1);
		death = playerScript.LoseWill (10);
		if (death)
			playerScript.GameOver();
		else
			playerScript.ManageEnergy (playerScript.maxEnergy/2);
			OpenNightCampPanel ();
	}

	public void UseNothing()
	{
		death = playerScript.LoseHealth (10);
		if (death)
			playerScript.GameOver();
		else {
			death = playerScript.LoseWill (10);
			if (death)
				playerScript.GameOver();
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
		campPanel.SetActive (false);
	}
}
