using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {

	public Text title;
	public Text directions;
	public bool instructions = false;
	public bool buttons = false;


	void Start () {
	
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			TitletoInstructions();
		}

	}

	void TitletoInstructions ()
	{
		if (title.text == "Press the spacebar during the game to help light the way!") 
		{
			Application.LoadLevel("scene1");
		}
		else if (title.text == "Collect all the Jellyfish Babies to win!") 
		{
			InstructionstoButtons ();
		} 
		else 
		{
			title.text = "Collect all the Jellyfish Babies to win!";
			directions.text = "Press Space to Continue";
		}

	}

	void InstructionstoButtons ()
	{
		title.fontSize = 20;
		title.text = "Press the spacebar during the game to help light the way!";
		directions.text = "Press Space to Start Game";
	}


}
