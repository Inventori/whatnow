﻿using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
	
	public GameObject ammoPrefab;
	public GameObject hitPrefab;
	public float ammoInterwall;
	
	private float timer;
	private Vector3 spawnPoint;
	
	public LayerMask mask = 8;
	
	private Animator anim;

	// Use this for initialization
	void Start () {
		
		timer = 0;
		anim = GetComponent<Animator>();
		
		spawnPoint = new Vector3(transform.position.x + 0.8f, transform.position.y + 0.3f, transform.position.z);
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;
		
		if (timer > ammoInterwall)
		{
			//anim.SetTrigger("Shoot");
			Instantiate(ammoPrefab, spawnPoint, Quaternion.Euler(0, 90, 0));
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 20, mask.value);
			
			if (hit.collider != null)
			{
				
				Instantiate(hitPrefab, hit.point, Quaternion.identity);
				
				if (hit.collider.tag == "Player")
				{
					//Whatever you want to happen to poor player
				}
			}
			
			timer = 0.0f;
		}
		
		
	
	}
}
