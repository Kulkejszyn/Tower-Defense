using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static bool gameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	public int levelToUnlock;

	void Start() {
		gameIsOver = false;
	}

	void Update() {
		if (gameIsOver)
			return;
		if (Input.GetKeyDown("e") && Application.isEditor)
			endGame();

		if (PlayerStats.lives <= 0) {
			endGame();
		}

	}
	public void winLevel() {
		Debug.Log("Level Won!");
		if (PlayerPrefs.GetInt("levelReached", 1) < levelToUnlock)
			PlayerPrefs.SetInt("levelReached", levelToUnlock);
		completeLevelUI.SetActive(true);
		gameIsOver = true;
	}

	void endGame() {
		gameIsOver = true;
		gameOverUI.SetActive(true);
	}

}