using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[HideInInspector] public GameObject selectedEnvironment;
	[HideInInspector] public bool movementOn = false;

	public GameObject gridManager;

	// Use this for initialization
	void Start () 
	{
		GridManager gridManagerScript = gridManager.GetComponent<GridManager> ();
		gridManagerScript.createZoneGrid ();
		gridManagerScript.createSquareGrid ();
	}
}
