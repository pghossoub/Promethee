using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Zone : Environment {

	//if there is a click on collider
	protected override void OnMouseDown()
	{
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			if (!gameManager.movementOn && !gameManager.windowOpened) {

				base.OnMouseDown ();

				HighlightZone ();

				//deactivate Travel Button;
				travelButton.interactable = false;
			}
		}
	}

	//Increase layer and transparency
	//Sorting Order = 3 
	//because 0 = default zone, 1= default square, 2= border of selected square, 4 = order of selected zone and 5 = Player
	void HighlightZone()
	{
		SpriteRenderer selectedSprite = GetComponent<SpriteRenderer> ();
		selectedSprite.sortingOrder = 3;
		selectedSprite.color = Color.white;
	}
}
