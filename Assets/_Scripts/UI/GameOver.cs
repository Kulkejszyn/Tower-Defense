using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public TMPro.TMP_Text roundsText;
	public SceneFader sceneFader;
	public string menuSceneName = "ScenesMainMenu";

	void OnEnable() {
		roundsText.text = PlayerStats.rounds.ToString();
	}

	public void retry() {
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	}

	public void menu() {
		sceneFader.FadeTo(0);
	}
}