using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public GameObject menuUI;
	public SceneFader sceneFader;

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
			toggle();
		}
	}

	public void toggle() {
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		menuUI.SetActive(!menuUI.activeSelf);
	}

	public void retry() {
		toggle();
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}

	public void menu() {
		toggle();
		sceneFader.FadeTo(0);
	}
}