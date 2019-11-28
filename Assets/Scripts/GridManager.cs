using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridManager : MonoBehaviour {

	[Serializable]
	public class TileList
	{
		public GameObject[] tiles;
	}

	public int zoneGridSize;
	public GameObject zoneBeachTile;
	public GameObject squareBeachTile;
	public GameObject[] zoneTiles;
	public GameObject[] squareTiles;
	public TileList[] squareZoneMatchingGrid;

	private GameObject[][] zoneGrid;
	private int zonePosX;
	private int zonePosY;
	private int squareGridSize;


	void Start () 
	{
		zoneGrid = new GameObject[zoneGridSize][];
		for (int i = 0; i < zoneGridSize; i++) {
			zoneGrid [i] = new GameObject[zoneGridSize];
		}
	}

	public void CreateZoneGrid()
	{
		GameObject zoneTile;
		for (int i = 0; i < zoneGridSize; i++) {
			
			for(int j = 0; j < zoneGridSize; j++) {
				
				if (i == 0 || j == 0 || i == zoneGridSize - 1 || j == zoneGridSize - 1)
					zoneTile = zoneBeachTile;
				else
					zoneTile = ChooseRandomZoneTile (i, j);
				
				zonePosX = i * 10 + 5;
				zonePosY = j * 10 + 5;
				zoneGrid [i] [j] = zoneTile;
				Instantiate (zoneTile, new Vector3 ((float)zonePosX, (float)zonePosY, 0.0f), transform.rotation);
			}
		}
	}

	GameObject ChooseRandomZoneTile(int i, int j)
	{
		float randomValue = UnityEngine.Random.value;
		if (randomValue <= 0.33 && i > 1 && i < zoneGridSize - 1) 
			//same as x-1
			return zoneGrid[i-1][j];
		else if (randomValue <= 0.66 && j > 1 && j < zoneGridSize - 1) 
			//same as y-1
			return zoneGrid[i][j-1];
		else {
			//random
			int randomIndex= UnityEngine.Random.Range(0, zoneTiles.Length);
			return zoneTiles [randomIndex];
		}
	}

	public void CreateSquareGrid()
	{
		squareGridSize = zoneGridSize - 1;
		GameObject squareTile;
		GameObject parentZoneTile;
		for (int i = 0; i < squareGridSize; i++) {
			for (int j = 0; j < squareGridSize; j++) {
				if (i == 0 || j == 0 || i == squareGridSize - 1 || j == squareGridSize - 1)
					squareTile = squareBeachTile;
				else {
					float randomValue = UnityEngine.Random.value;
					if (randomValue <= 0.25)
						parentZoneTile = zoneGrid [i] [j];
					else if (randomValue <= 0.5)
						parentZoneTile = zoneGrid [i+1] [j];
					else if (randomValue <= 0.75)
						parentZoneTile = zoneGrid [i] [j+1];
					else
						parentZoneTile = zoneGrid [i+1] [j+1];

					int k = 0;
					foreach (TileList tilelist in squareZoneMatchingGrid){
						if (tilelist.tiles[0].name == parentZoneTile.name)
							break;
						else
							k++;
					}
					int randomIndex= UnityEngine.Random.Range(1, squareZoneMatchingGrid[k].tiles.Length);
					squareTile = squareZoneMatchingGrid [k].tiles [randomIndex];
				}
				zonePosX = i * 10 + 10;
				zonePosY = j * 10 + 10;
				Instantiate (squareTile, new Vector3 ((float)zonePosX, (float)zonePosY, 0.0f), transform.rotation);
			}
		}
	}
}
