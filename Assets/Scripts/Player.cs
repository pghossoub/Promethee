using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int health = 40;
	public int maxHealth = 50;
	public Text healthDisplay;
	public int will = 30;
	public int maxWill = 50;
	public Text willDisplay;
	public int energy = 10;
	public int maxEnergy = 50;
	public Text energyDisplay;
	public int food = 2;
	public int maxFood = 5;
	public Text foodDisplay;
	public int water = 2;
	public int maxWater = 10;
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
		healthDisplay.text = string.Format("{0}/{1}", health, maxHealth);
		willDisplay.text = string.Format("{0}/{1}", will, maxWill);
		energyDisplay.text = string.Format("{0}/{1}", energy, maxEnergy);
		foodDisplay.text = string.Format("{0}/{1}", food, maxFood);
		waterDisplay.text = string.Format("{0}/{1}", water, maxWater);
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
			ManageWater (-1);
			return false;
		}
		else{
			return LoseHealth(10);
		}
	}

	public void ManageEnergy(int val)
	{
		if (energy + val > maxEnergy)
			energy = maxEnergy;
		else if (energy + val < 0)
			energy = 0;
		else
			energy += val;
		energyDisplay.text = string.Format("{0}/{1}", energy, maxEnergy);
	}

	public void ManageWater(int val)
	{
		if (water + val > maxWater)
			water = maxWater;
		else if (water + val < 0)
			water = 0;
		else
			water += val;
		waterDisplay.text = string.Format("{0}/{1}", water, maxWater);
	}

	public void ManageFood(int val)
	{
		if (food + val > maxFood)
			food = maxFood;
		else if (food + val < 0)
			food = 0;
		else
			food += val;
		foodDisplay.text = string.Format("{0}/{1}", food, maxFood);
	}

	public void GainHealth(int val)
	{
		if (health + val > maxHealth)
			health = maxHealth;
		else
			health += val;
		healthDisplay.text = string.Format("{0}/{1}", health, maxHealth);
	}

	public bool LoseHealth(int loss)
	{
		health -= loss;
		healthDisplay.text = string.Format("{0}/{1}", health, maxHealth);
		if (health <= 0) {
			return true;
		}
		return false;
	}

	public void GainWill(int val)
	{
		if (will + val > maxHealth)
			will = maxWill;
		else
			will += val;
		willDisplay.text = string.Format("{0}/{1}", will, maxWill);
	}

	public bool LoseWill(int loss)
	{
		will -= loss;
		willDisplay.text = string.Format("{0}/{1}", will, maxWill);
		if (will <= 0) {
			return true;
		}
		return false;
	}

	public void GameOver()
	{
		//Peut contenir un Switch(string) et toutes les morts possibles
		gameOverPanel.SetActive (true);
	}
}
