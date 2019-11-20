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
	public float food = 2;
	public Text foodDisplay;
	public float water = 2;
	public Text waterDisplay;

	public float speed;
	public Button travelButton;
	public GameObject gameOverPanel;

	private GameManager gameManager;
	private Animator animatorPlayer;
	private bool death = false;

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

		death = DrinkWater ();

		if (death)
			GameOver ();
		
		else {

			Vector3 targetPosition = gameManager.selectedEnvironment.gameObject.GetComponent<Transform> ().position;

			float step = speed * Time.deltaTime;

			FacingAnimation (targetPosition - transform.position);

			StartCoroutine (Move (targetPosition, step));
		}

	}

	void FacingAnimation(Vector3 direction)
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

	bool DrinkWater()
	{
		if (water > 0){
			LoseWater (1);
			return false;
		}
		else{
			return LoseHealth(10);
		}
	}

	void LoseWater(int loss)
	{
		water -= loss;
		waterDisplay.text = string.Format ("{0}/50", water);
	}

	bool LoseHealth(int loss)
	{
		health -= loss;
		healthDisplay.text = string.Format ("{0}/50", health);
		if (health <= 0) {
			return true;
		}
		return false;
	}

	void GameOver()
	{
		gameOverPanel.SetActive (true);
	}
}
