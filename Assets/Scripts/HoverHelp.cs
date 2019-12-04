using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class HoverHelp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private GameManager gameManager;

	void Start()
	{
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		switch (gameObject.name) {

		case "Travel_Button":
			
			if (gameManager.player.water > 0) {
				gameManager.panelModSupply.SetActive (true);
				gameManager.waterMod.text = "- 1";
			} else {
				gameManager.panelModIdentity.SetActive (true);
				gameManager.healthMod.text = "- 10";
			}
			break;


		case "Button_Camp_Full":

			gameManager.panelModIdentity.SetActive (true);
			gameManager.panelModSupply.SetActive (true);
			gameManager.healthMod.text = "+ 20";
			gameManager.willMod.text = "+ 20";
			gameManager.energyMod.text = string.Format ("+ {0}", gameManager.player.maxEnergy);
			gameManager.waterMod.text = "- 1";
			gameManager.foodMod.text = "- 1";
			break;

		case "Button_Camp_Water":

			gameManager.panelModIdentity.SetActive (true);
			gameManager.panelModSupply.SetActive (true);
			gameManager.willMod.text = "- 10";
			gameManager.energyMod.text = string.Format ("+ {0}", gameManager.player.maxEnergy / 2);
			gameManager.waterMod.text = "- 1";
			break;

		case "Button_Camp_Food":

			gameManager.panelModIdentity.SetActive (true);
			gameManager.panelModSupply.SetActive (true);
			gameManager.healthMod.text = "- 10";
			gameManager.energyMod.text = string.Format ("+ {0}", gameManager.player.maxEnergy / 2);
			gameManager.foodMod.text = "- 1";
			break;

		case "Button_Camp_Void":

			gameManager.panelModIdentity.SetActive (true);
			gameManager.healthMod.text = "- 10";
			gameManager.willMod.text = "- 10";
			gameManager.energyMod.text = string.Format ("+ {0}", gameManager.player.maxEnergy / 2);
			break;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		gameManager.panelModIdentity.SetActive (false);
		gameManager.panelModSupply.SetActive (false);
		gameManager.healthMod.text = "";
		gameManager.willMod.text = "";
		gameManager.energyMod.text = "";
		gameManager.foodMod.text = "";
		gameManager.waterMod.text = "";
	}
}
