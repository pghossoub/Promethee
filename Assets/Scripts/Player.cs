using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float health = 40;
	public Text healthDisplay;
	public float will = 30;
	public Text willDisplay;
	public float energy = 10;
	public Text energyDisplay;
	public float food = 4;
	public Text foodDisplay;
	public float water = 8;
	public Text waterDisplay;

	public float speed;
	public Button travelButton;

	private GameManager gameManager;
	private Animator animatorPlayer;

	void Start () 
	{
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		animatorPlayer = GetComponent<Animator> ();
		healthDisplay.text = string.Format("{0}/50", health);
		willDisplay.text = string.Format("{0}/50", will);
		energyDisplay.text = string.Format("{0}/50", energy);
		foodDisplay.text = string.Format("{0}/5", food);
		waterDisplay.text = string.Format("{0}/10", water);
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
