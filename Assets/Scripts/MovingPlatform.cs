using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	private float move;
	public float moveDistance;
	public float maxDistance;
	public float minDistance;


	// Use this for initialization
	void Start () {
		move = 2;
		minDistance = transform.position.x - moveDistance;
		maxDistance = transform.position.x + moveDistance;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += (new Vector3 (1, 0, 0)) * move * Time.deltaTime;

		if (transform.position.x >= maxDistance)
		{
			move = -2;
		}
		if (transform.position.x <= minDistance)
		{
			move = 2;

	}
	}}
