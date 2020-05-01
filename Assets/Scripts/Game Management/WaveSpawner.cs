using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {
	public Wave[] waves;
	public static int enemiesAlive = 0;
	public float timeBetweenWaves = 5f;
	public GameManager gameManager;
	public TMPro.TMP_Text waveCountdownText;

	private Transform spawnPoint;
	private float countdown = 2f;
	private int waveIndex = 0;

	private void Start() {
		enemiesAlive = 0;
		spawnPoint = LevelInfo.Instance.spawnPoint;
	}

	private void Update() {
		if (enemiesAlive > 0) {
			return;
		}

		if (countdown <= 0f) {
			StartCoroutine(spawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp(countdown, 0, Mathf.Infinity);
		waveCountdownText.text = String.Format("{0:0.00}", countdown);
	}

	IEnumerator spawnWave() {
		PlayerStats.rounds++;

		Wave wave = waves[waveIndex];
		enemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++) {
			spawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}
		waveIndex++;

		if (waveIndex == waves.Length) {
			gameManager.winLevel();
			this.enabled = false;
		}
	}

	private void spawnEnemy(GameObject enemy) {

		Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity, spawnPoint.parent);
	}

}