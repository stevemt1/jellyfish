using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject lightItem;
	public GameObject babyJelly;
	public GameObject octopus;
	public GameObject bubbles;
	public GameObject[] enemyList;
	public float waitingForNextSpawn = 6f;
	public float waitingForNextEnemySpawn = 3f;
	public float countdown = 6f;
	public float countdown2 = 3f;

	public int xMin = -90;
	public int xMax = 90;
	public int yMin = -90;
	public int yMax = 90;

	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		SpawnBigBoss();
		SpawnGoals ();
	}
	
	void Update () 
	{
	
		countdown -= Time.deltaTime;
		countdown2 -= Time.deltaTime;
		if (countdown <= 0) 
		{
			SpawnItems ();
			countdown = waitingForNextSpawn;
		}
		if (countdown2 <= 0)
		{
			SpawnEnemies(enemyList);
			countdown2 = waitingForNextEnemySpawn;
		}
	}

	void SpawnItems ()
	{

		Vector2 newspawn = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));

		Instantiate (lightItem, newspawn, transform.rotation);

		Vector2 newspawn2 = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));

		Instantiate (bubbles, newspawn2, transform.rotation);

	}

	void SpawnBigBoss ()
	{
		Vector2 newspawn = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));

		Instantiate (octopus, newspawn, transform.rotation);
	}

	void SpawnEnemies (GameObject[] enemyList)
	{

		Vector2 newspawn = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));
		GameObject enemyChoice = enemyList [Random.Range (0, enemyList.Length)];

		Instantiate (enemyChoice, newspawn, transform.rotation);
	}

	void SpawnGoals ()
	{
		Vector2 firstQuadSpawn = new Vector2 (Random.Range (5, 90), Random.Range (5, 90));
		Vector2 secondQuadSpawn = new Vector2 (Random.Range (-90, 5), Random.Range (5, 90));
		Vector2 thirdQuadSpawn = new Vector2 (Random.Range (-90, 5), Random.Range (-90, 5));
		Vector2 fourthQuadSpawn = new Vector2 (Random.Range (5, 90), Random.Range (-90, 5));

		Instantiate (babyJelly, firstQuadSpawn, transform.rotation);
		Instantiate (babyJelly, secondQuadSpawn, transform.rotation);
		Instantiate (babyJelly, thirdQuadSpawn, transform.rotation);
		Instantiate (babyJelly, fourthQuadSpawn, transform.rotation);
		

	}

}
