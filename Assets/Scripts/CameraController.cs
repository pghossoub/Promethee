using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	void Start ()
	{
		//offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		//transform.position = player.transform.position + offset;
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -1f);
	}
}