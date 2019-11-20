using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[HideInInspector] public GameObject selectedEnvironment;
	[HideInInspector] public bool movementOn = false;

	public GameObject gridManager;
	public Text environmentTitle;
	public Text environmentDescription;
	public Text environmentMetaDescription;

	// Use this for initialization
	void Start () 
	{
		GridManager gridManagerScript = gridManager.GetComponent<GridManager> ();
		gridManagerScript.CreateZoneGrid ();
		gridManagerScript.CreateSquareGrid ();
	}

	public void UpdateUIEnvironmentDescription()
	{
		switch (selectedEnvironment.name) {

		case "square_ashe(Clone)":
		case "zone_ashe(Clone)":
			environmentTitle.text = "Cendres";
			environmentDescription.text = "Des cendres à perte de vue, plus rien ne pousse ici. Peut être à cause d’une ancienne activité volcanique.";
			if (selectedEnvironment.GetComponent<Square> () != null)
				environmentMetaDescription.text = "Défis Psychologique ou Scientifique";
			if (selectedEnvironment.GetComponent<Zone> () != null)
				environmentMetaDescription.text = "Défis Psychologique ou Social";
			break;

		case "square_beach(Clone)":
		case "zone_beach(Clone)":
			environmentTitle.text = "Plage";
			environmentDescription.text = "Du sable, des galets, un soleil étouffant et rien d’autre à l’horizon qu’un océan d’un bleu turquoise.";
			if (selectedEnvironment.GetComponent<Square> () != null)
				environmentMetaDescription.text = "Défis Social ou Physique";
			if (selectedEnvironment.GetComponent<Zone> () != null)
				environmentMetaDescription.text = "Défis Social ou de Survie";
			break;

		case "square_forest(Clone)":
		case "zone_forest(Clone)":
			environmentTitle.text = "Forêt";
			environmentDescription.text = "Un mélange d’arbres feuillus et de conifères de différentes espèces, abritant beaucoup d’animaux et de rares traces d’activité humaine.";
			if (selectedEnvironment.GetComponent<Square> () != null)
				environmentMetaDescription.text = "Défis Social ou de Survie";
			if (selectedEnvironment.GetComponent<Zone> () != null)
				environmentMetaDescription.text = "Défis Social ou Scientifique";
			break;

		case "square_jungle(Clone)":
		case "zone_jungle(Clone)":
			environmentTitle.text = "Jungle";
			environmentDescription.text = "Une végétation dense rend la progression difficile, et des animaux rares et dangereux foisonnent.";
			if (selectedEnvironment.GetComponent<Square> () != null)
				environmentMetaDescription.text = "Défis de Survie ou Scientifique";
			if (selectedEnvironment.GetComponent<Zone> () != null)
				environmentMetaDescription.text = "Défis de Survie ou de Combat";
			break;

		case "square_lake(Clone)":
			environmentTitle.text = "Lac";
			environmentDescription.text = "Un coin d’eau potable, fréquenté aussi bien par des animaux que par des autochtones territoriaux.";
			environmentMetaDescription.text = "Défis de Combat ou de Survie";
			break;

		case "square_mountain(Clone)":
		case "zone_mountain(Clone)":
			environmentTitle.text = "Montagne";
			environmentDescription.text = "Un chemin escarpé slalomant entre les falaises et les crevasses, longeant aussi bien quelques abris que des tanières de prédateurs.";
			if (selectedEnvironment.GetComponent<Square> () != null)
				environmentMetaDescription.text = "Défis Physique ou Scientifique";
			if (selectedEnvironment.GetComponent<Zone> () != null)
				environmentMetaDescription.text = "Défis Physique ou de Survie";
			break;

		case "square_ruins(Clone)":
		case "zone_ruins(Clone)":
			environmentTitle.text = "Ruines";
			environmentDescription.text = "D’antiques constructions, des curiosités architecturales, mais aussi des pièges. Peu de curieux s’aventurent ici, même parmi les autochtones.";
			if (selectedEnvironment.GetComponent<Square> () != null)
				environmentMetaDescription.text = "Défis de Combat ou Psychologique";
			if (selectedEnvironment.GetComponent<Zone> () != null)
				environmentMetaDescription.text = "Défis de Combat ou Physique";
			break;

		case "square_village(Clone)":
			environmentTitle.text = "Village";
			environmentDescription.text = "Des autochtones, ou d’autres rescapés? Sont-ils hostiles ou amicaux?";
			environmentMetaDescription.text = "Défis Social ou de Combat";
			break;

		case "square_vulcano(Clone)":
		case "zone_vulcano(Clone)":
			environmentTitle.text = "Volcan";
			environmentDescription.text = "Du magma dans le cratère, des coulées de lave bordant la zone d’activité volcanique, aucun être vivant en vue.";
			if (selectedEnvironment.GetComponent<Square> () != null)
				environmentMetaDescription.text = "Défis Physique ou Scientifique";
			if (selectedEnvironment.GetComponent<Zone> () != null)
				environmentMetaDescription.text = "Défis Physique ou Psychologique";
			break;

		case "square_swamp(Clone)":
		case "zone_swamp(Clone)":
			environmentTitle.text = "Marais";
			environmentDescription.text = "Un décors mystérieux composé de plantes et de bourbiers, cachant plus de vie que l’on ne pourrait croire à première vue.";
			if (selectedEnvironment.GetComponent<Square> () != null)
				environmentMetaDescription.text = "Défis Psychologique ou Scientifique";
			if (selectedEnvironment.GetComponent<Zone> () != null)
				environmentMetaDescription.text = "Défis Psychologique ou de Combat";
			break;

		default:
			environmentTitle.text = "";
			environmentDescription.text = "";
			environmentMetaDescription.text = "";
			break;
		}
	}
}
