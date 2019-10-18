using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Environment : MonoBehaviour {

	public GameObject select;

	protected Button travelButton;
	protected GameManager gameManager;

	protected virtual void Start () 
	{
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		travelButton = GameObject.Find("Travel_Button").GetComponent<Button> ();

	}

	//if there is a click on collider
	protected virtual void OnMouseDown()
	{
		// Check if the last selected enviro is a zone.
		if (gameManager.selectedEnvironment != null) {
			
			if (gameManager.selectedEnvironment.gameObject.GetComponent<Zone>() != null) {
				resetZoneDisplay ();
				//gameManager.selectedEnvironment = null;
			}
		}

		//Destroy any remaining selection
		foreach (GameObject selectToDestroy in GameObject.FindGameObjectsWithTag ("select")){
			Destroy(selectToDestroy);
		}

		//Create selection
		Instantiate (select, transform);

		//Save selected zone 
		gameManager.selectedEnvironment = gameObject;
	}

	//Reset transparency and layer to starting value
	void resetZoneDisplay()
	{
		SpriteRenderer selectedSprite = gameManager.selectedEnvironment.GetComponent<SpriteRenderer> ();
		selectedSprite.sortingOrder = 0;
		selectedSprite.color = new Color(1f, 1f, 1f, 0.5f);
	}
}
