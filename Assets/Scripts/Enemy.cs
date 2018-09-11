using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Transform target;
	public float speed;
	private Animator animator;
	public Player player;
	public float distanceToChase = 30f;
	public float countdown = 5f;

	void Start () 
	{
		animator = GetComponent<Animator> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		player = GetComponent<Player> ();
	}
	
	void Update () 
	{
		Movement ();
	}

	void onTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") 
		{
			player.health -= 1;
			player.healthSlider.value -= 1;
		}
	}

	void Movement()
	{

		if (Vector3.Distance (transform.position, target.position) <= distanceToChase) 
		{
			transform.LookAt (target.position);
			transform.Rotate(new Vector3(0,-90,0),Space.Self);
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		} 
		else 
		{
			countdown -= Time.deltaTime;
			if (countdown <= 0)
			{
				transform.Rotate(new Vector3(0,90,0),Space.Self);
				countdown = 5f;
			}
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}
	}
}
