﻿using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public CreaturesStatistics stats; 
	public GameObject[] activeGame;
	public GameObject[] GameOverObjects;
	public bool gameStatred = false;

	void Start() {
		InvokeRepeating ("CheckStatus", 3, 3);
	}

	public void gameStarted(){
		Invoke ("_gameStarted", 3f);
	}
	public void gamePaused(){
		gameStatred = false;
	}
	private void _gameStarted(){
		gameStatred = true;
	}


	// Update is called once per frame
	void CheckStatus () {
		if (gameStatred && stats.count < 1) {
			foreach (GameObject g in activeGame) {
				g.SetActive (false);
			}
			foreach (GameObject g in GameOverObjects) {
				g.SetActive (true);
			}
		}
	}
}
