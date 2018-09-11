using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 2f;
	public int health = 20;
	public int items = 3;
	public int babies = 0;
	public Slider healthSlider;
	public Text babyJellyText;

	private Animator animator;
	private GameObject playerlight;
	private Vector3 rightmovement = new Vector3(5f, 0f, 0f);
	private Vector3 upmovement = new Vector3(0f, 5f, 0f);
	public float countdown = 10f;
	public bool lit = false;


	void Start () 
	{
		healthSlider.value = 20;
		animator = GetComponent<Animator> ();
		playerlight = transform.Find ("Light").gameObject;

		babyJellyText.text = "Jelly Babies Collected: " + babies;
	}

	void Update()
	{
		Movement ();

		if (!lit && items > 0) 
		{
			LightUp ();
		}
		if (lit) 
		{
			countdown -= Time.deltaTime;
			if (countdown <= 0)
			{
				LightDown();
				countdown = 10f;
			}
		}


		if (Input.GetKey (KeyCode.R)) 
		{
			Application.LoadLevel("TitleScreen");
		}

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy") {

			animator.SetTrigger("PlayerHit");
			health -= 1;

			healthSlider.value -= 1;

			CheckGameOver();	
		}

		if (other.tag == "Octopus") {
			animator.SetTrigger("PlayerHit");
			health -= 5;

			healthSlider.value -= 5;

			CheckGameOver();
		}

		if (other.tag == "Item") {
			if (items < 3)
				items++;
			other.gameObject.SetActive(false);
		}

		if (other.tag == "Baby") {
			babies++;
			babyJellyText.text = "Jelly Babies Collected: " + babies;
			other.gameObject.SetActive(false);

			CheckGameOver();
		}
	}

	void LightUp ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			animator.SetTrigger("Glow");
			items--;
			playerlight.gameObject.transform.localScale += new Vector3 (25, 25, 0);
			lit = true;
		}
	}

	void LightDown ()
	{
		playerlight.gameObject.transform.localScale -= new Vector3 (25, 25, 0);
		lit = false;
	}
	
	void Movement()
	{
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			transform.Translate (upmovement * speed * Time.deltaTime);
			Vector3 pos = transform.position;
			pos.y = Mathf.Clamp (pos .y, -100, 100);
			transform.position = pos;
		}
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			transform.Translate (-upmovement * speed * Time.deltaTime);
			Vector3 pos = transform.position;
			pos.y = Mathf.Clamp(pos .y, -100, 100);
			transform.position = pos;
		}

		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.Translate (rightmovement * speed * Time.deltaTime);
			Vector3 pos = transform.position;
			pos.x = Mathf.Clamp(pos .x, -100, 100);
			transform.position = pos;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.Translate (-rightmovement * speed * Time.deltaTime);
			Vector3 pos = transform.position;
			pos.x = Mathf.Clamp(pos .x, -100, 100);
			transform.position = pos;
		}

	}

	void CheckGameOver()
	{
		if (health <= 0) 
		{
			Application.LoadLevel("GameOver");
		}

		if (babies == 4) 
		{
			Application.LoadLevel("Congrats");
		}
	}

}
