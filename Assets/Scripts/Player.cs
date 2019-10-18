using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float speed;
	public Button travelButton;

	private GameManager gameManager;
	private Animator animatorPlayer;

	void Start () 
	{
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		animatorPlayer = GetComponent<Animator> ();
	}

	public void LaunchMove()
	{
		gameManager.movementOn = true;

		travelButton.interactable = false;

		Vector3 targetPosition = gameManager.selectedEnvironment.gameObject.GetComponent<Transform> ().position;

		float step =  speed * Time.deltaTime;

		facingAnimation (targetPosition - transform.position);

		StartCoroutine (Move (targetPosition, step));

	}

	void facingAnimation(Vector3 direction)
	{
		if(direction.x > 0)
			animatorPlayer.SetTrigger ("facingRight");
		else if (direction.x < 0)
			animatorPlayer.SetTrigger ("facingLeft");
		else if (direction.y > 0)
			animatorPlayer.SetTrigger ("facingUp");
	}

	IEnumerator Move(Vector3 targetPosition, float step)
	{
		while (transform.position != targetPosition) {
			transform.position = Vector3.MoveTowards (transform.position, targetPosition, step);
			yield return new WaitForSeconds (Time.deltaTime);
		}
		animatorPlayer.SetTrigger ("facingDown");
		gameManager.movementOn = false;
	}
}
