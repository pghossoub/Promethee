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
			if (!gameManager.movementOn && !gameManager.windowOpened) {

				base.OnMouseDown ();

				EnableTravelSearch ();
			}
		}
	}

	protected void EnableTravelSearch()
	{
		float distanceX = transform.position.x - playerTr.position.x;
		float distanceY = transform.position.y- playerTr.position.y;

		if ((distanceX == 0) && (distanceY == 0)) {

			travelButton.interactable = false;

		}
		else if ((distanceX >= -10 && distanceX <= 10) && (distanceY >= -10 && distanceY <= 10)) {
			//activate Travel Button
			travelButton.interactable = true;

		} else {
			//deactivate Travel Button
			travelButton.interactable = false;
		}
	}
}
