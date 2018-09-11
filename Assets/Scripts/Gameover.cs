using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour {
	
	void Update () 
	{
		if (Input.GetKey(KeyCode.R))
		{
			Application.LoadLevel("TitleScreen");
		}
	}
}
