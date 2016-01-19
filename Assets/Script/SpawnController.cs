﻿using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject aiPrefab;

	private GameObject[] spawnPoints;

	public bool start = false;

	// Use this for initialization
	void Start () {
		if (spawnPoints == null)
			spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");

		int playerStart = Random.Range (1, spawnPoints.Length) - 1;
		for (int i = 0; i < spawnPoints.Length; i++) {
			GameObject o;

			if(i == playerStart)
				o = (GameObject) Instantiate (playerPrefab, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
				
			else
				o = (GameObject) Instantiate (aiPrefab, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);

			//Allocate camera to the rogue
			ControllerScript cs = o.GetComponent<ControllerScript>();
			AIController aic = o.GetComponent<AIController>();
			switch(i)
			{
			case 0:
				if(cs != null) cs.startCamera = GameObject.Find ("RogueCamera1").GetComponent<Camera>();
				if(aic != null) aic.cam = GameObject.Find ("RogueCamera1").GetComponent<Camera>();
				break;
			case 1:
				if(cs != null) cs.startCamera = GameObject.Find ("RogueCamera2").GetComponent<Camera>();
				if(aic != null) aic.cam = GameObject.Find ("RogueCamera2").GetComponent<Camera>();
				break;
			case 2:
				if(cs != null) cs.startCamera = GameObject.Find ("RogueCamera3").GetComponent<Camera>();
				if(aic != null) aic.cam = GameObject.Find ("RogueCamera3").GetComponent<Camera>();
				break;
			default:
				print ("Index for allocating camera to rogue out of range.");
				break;
			}
		}

		//If player camera was not attributed, allocate it to position 1
		if (GameObject.FindWithTag ("RoguePlayer").GetComponent<ControllerScript> ().getCamera () == null)
			GameObject.FindWithTag ("RoguePlayer").GetComponent<ControllerScript> ().startCamera = 
				GameObject.Find ("RogueCamera1").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F5)) {
			reset ();
		}
	}

	private void reset(){

	}
}