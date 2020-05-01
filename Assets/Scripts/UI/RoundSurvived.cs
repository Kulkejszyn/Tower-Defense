using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSurvived : MonoBehaviour {
	public TMPro.TMP_Text roundsText;
	void OnEnable() {
		StartCoroutine(animateText());
	}

	IEnumerator animateText() {
		int round = 0;
		roundsText.text = "0";

		yield return new WaitForSeconds(0.7f);

		while (int.Parse(roundsText.text) < PlayerStats.rounds) {
			roundsText.text = round.ToString();
			round++;
			yield return new WaitForSeconds(0.05f);
		}
	}

}