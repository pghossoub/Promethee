using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Square : Environment {
	
	private GameObject player;
	private Transform playerTr;

	protected override void Start ()
	{
		base.Start ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerTr = player.GetComponent<Transform>();
	}

	protected override void OnMouseDown()
	{
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			if (!gameManager.movementOn) {
			
				Debug.Log ("Click on square");

				base.OnMouseDown ();

				enableTravelSearch ();
			}
		}
	}

	protected void enableTravelSearch()
	{
		float distanceX = transform.position.x - playerTr.position.x;
		float distanceY = transform.position.y- playerTr.position.y;

		if ((distanceX == 0) && (distanceY == 0)) {
			Debug.Log ("Travel impossible, search possible");
			//Debug.Log ("DistX " + distanceX.ToString());
			//Debug.Log ("DistY " + distanceY.ToString());
			travelButton.interactable = false;

		}
		else if ((distanceX >= -10 && distanceX <= 10) && (distanceY >= -10 && distanceY <= 10)) {

			Debug.Log ("Travel possible");
			//activate Travel Button
			travelButton.interactable = true;

		} else {
			Debug.Log ("Travel impossible");
			//deactivate Travel Button
			travelButton.interactable = false;
		}
	}
}
