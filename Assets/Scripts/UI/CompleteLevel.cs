using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour {

	public SceneFader sceneFader;

	public void menu() {
		sceneFader.FadeTo(0);
	}

	public void nextLevel() {
		if(SceneManager.sceneCount == SceneManager.GetActiveScene().buildIndex + 1)
		{
			Debug.Log("No more scenes");
			return;
		}
		sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex + 1);
	}

}