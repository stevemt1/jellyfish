using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject gameManager;
	public GameObject player;
	private Vector3 offset;


	void Awake()
	{
		if (GameManager.instance == null)
			Instantiate (gameManager);
	}
	
	void Start () 
	{
		offset = transform.position - player.transform.position;
	
	}

	void LateUpdate () 
	{

		transform.position = player.transform.position + offset;
	
	}
}
