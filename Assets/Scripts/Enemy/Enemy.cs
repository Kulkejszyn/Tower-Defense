using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyMovement))]
[SelectionBase]
public class Enemy : MonoBehaviour {
	[HideInInspector]
	public float speed;
	public float startSpeed = 10f;
	public float health = 100;
	public int worth = 30;
	public GameObject deathEffect;

	public EnemyHealthBar enemyHealthBar;
	private float maxHealth;
	private bool isDead = false;

	private void Start() {
		maxHealth = health;
		speed = startSpeed;
	}

	public void takeDamage(float damage) {
		health -= damage;
		enemyHealthBar.updateHealthBart(health / maxHealth);
		if (health <= 0 && !isDead)
			die();
	}

	private void die() {
		WaveSpawner.enemiesAlive--;
		GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);
		PlayerStats.money += worth;
		Destroy(gameObject);
		isDead = true;
	}

	public void slow(float slowPercent) {
		speed = startSpeed * slowPercent;
		Invoke("resetSpeed", 1.0f);
	}

	void resetSpeed() {
		speed = startSpeed;
	}
}