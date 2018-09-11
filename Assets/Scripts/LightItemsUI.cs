using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LightItemsUI : MonoBehaviour {

	public GameObject item1;
	public GameObject item2;
	public GameObject item3;

	public Player player;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	
	void Update () 
	{
		ChangeItemImages ();
	}

	void ChangeItemImages()
	{
		if (player.items == 3) 
		{
			item1.SetActive(true);
			item2.SetActive(true);
			item3.SetActive(true);
		}
		if (player.items == 2) 
		{
			item1.SetActive (true);
			item2.SetActive (true);
			item3.SetActive(false);
		}
		if (player.items == 1) 
		{
			item1.SetActive (true);
			item2.SetActive(false);
			item3.SetActive(false);
		}
		if (player.items == 0) 
		{
			item1.SetActive(false);
			item2.SetActive(false);
			item3.SetActive(false);
		}
	}
}
