using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour {
	public Image image;
	public AnimationCurve curve;

	private void Start() {
		StartCoroutine(fadeIn());
	}

	public void FadeTo(string scene) {
		StartCoroutine(fadeOut(scene));
	}

	public void FadeTo(int index) {
		StartCoroutine(fadeOut(index));
	}

	IEnumerator fadeOut(string scene) {
		float t = 0f;
		while (t < 1f) {
			t += Time.deltaTime;
			float a = curve.Evaluate(t);
			image.color = new Color(0f, 0f, 0f, a);
			yield return 0;
		}
		SceneManager.LoadScene(scene);
	}

	IEnumerator fadeOut(int index) {
		float t = 0f;
		while (t < 1f) {
			t += Time.deltaTime;
			float a = curve.Evaluate(t);
			image.color = new Color(0f, 0f, 0f, a);
			yield return 0;
		}
		SceneManager.LoadScene(index);
	}

	internal void FadeTo(object menuSceneName) {
		throw new NotImplementedException();
	}

	IEnumerator fadeIn() {
		float t = 1f;

		while (t > 0f) {
			t -= Time.deltaTime;
			float a = curve.Evaluate(t);
			image.color = new Color(0f, 0f, 0f, a);
			yield return 0;
		}
	}

}