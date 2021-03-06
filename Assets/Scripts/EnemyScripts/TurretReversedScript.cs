﻿using UnityEngine;
using System.Collections;

public class TurretReversedScript : MonoBehaviour {
	
	public GameObject ammoPrefab;
	public GameObject hitPrefab;
	public GameObject player;
	public PlayerScript pS;
	public float ammoInterwall;
	
	private float timer;
	private Vector3 spawnPoint;
	
	private Animator anim;
	
	public LayerMask mask = 8;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		pS = player.GetComponent<PlayerScript>();
		
		anim = GetComponent<Animator>();
		timer = 0;
		
		spawnPoint = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.25f, transform.position.z);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;
		
		if (timer > ammoInterwall)
		{
			anim.SetTrigger("Shoot");
			Instantiate(ammoPrefab, spawnPoint, Quaternion.Euler(0, -90, 180));
			RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, 20, mask.value);
			
			if (hit.collider != null)
			{
				
				Instantiate(hitPrefab, hit.point, Quaternion.identity);
				
				if (hit.collider.tag == "Player")
				{
					pS.hitPoint--;
					//Whatever you want to happen to poor player
				}
			}
			timer = 0.0f;
		}
	
	}
}
