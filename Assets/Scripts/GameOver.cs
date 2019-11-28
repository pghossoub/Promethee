using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Text gameOverTitle;
	public Text gameOverText;
	public GameObject gameOverImage;
	public Sprite dehydrationSprite;
	public Sprite starvationSprite;

	private GameManager gameManager;
	private Image gameOverImageSource;


	public void GameOverDisplay(string causeOfDeath)
	{

		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		gameOverImageSource = gameOverImage.GetComponent<Image> ();

		switch (causeOfDeath) {

		case "dehydration":
			gameOverImageSource.sprite = dehydrationSprite;
			gameOverTitle.text = "Deshydratation";
			gameOverText.text = "\t Il y a une limite à la résistance à la soif. Les nausées et les engourdissements ont laissés place à une fatigue extrême qui vous empêche d'agir et de réfléchir, jusqu'à ce que vous vous évanouissez.";
			break;

		case "starvation":
			gameOverImageSource.sprite = starvationSprite;
			gameOverTitle.text = "Famine";
			gameOverText.text = "\t  Morceau par morceau, chacune de vos pensées est remplacée par une faim obsédante. Vos dernières résistances à la magie de l'île s'écroulent alors, et vous rejoignez les autres anciens explorateurs dans leur horde sauvage.";
			break;
		}

		gameObject.SetActive (true);
		gameManager.windowOpened = true;
		gameObject.GetComponent<AudioSource> ().Play ();
	}
}