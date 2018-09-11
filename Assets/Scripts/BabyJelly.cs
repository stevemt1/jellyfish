using UnityEngine;
using System.Collections;

public class BabyJelly : MonoBehaviour {

	public Transform target;
	public float speed = 1f;

	public float distanceToRunAway = 10f;

	void Start () 
	{
		target = GameObject.FindGameObjectWithTag ("Octopus").transform;
	}
	
	void Update () 
	{
		if (Vector3.Distance (transform.position, target.position) <= distanceToRunAway) {
			transform.LookAt (target.position);
			transform.Rotate (new Vector3 (0, 90, 0), Space.Self);
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}
	}
}
