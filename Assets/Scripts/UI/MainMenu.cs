using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

	public SceneFader sceneFader;

	public void play() {
		sceneFader.FadeTo(levelToLoad);
	}

	public void quit() {
		Debug.Log("quit");
		Application.Quit();
	}
}