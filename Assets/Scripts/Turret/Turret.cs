using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Turret : MonoBehaviour {

	private Transform target;
	private Enemy enemy;

	[Header("General")]
	public float range = 15f;
	public float rotationSpeed = 5f;
	[Header("Use Bullets (Default)")]
	public float fireRate = 1f;
	[Header("Unity setup fields")]

	public Transform partToRotate = null;
	[SerializeField] GameObject bulletPrefab = null;
	[SerializeField] Transform firePoint = null;
	[SerializeField] private string enemyTag = "Enemy";
	[Header("Use Laser")]
	[SerializeField] bool useLaser = false;
	[SerializeField] float slowPercent = 0.5f;
	[SerializeField] LineRenderer lineRenderer;
	[SerializeField] ParticleSystem impactEffect;
	[SerializeField] Light impactLight;
	[SerializeField] float damageOverTime = 1f;

	private float fireCountdown = 0;

	void Start() {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	void Update() {
		if (target == null) {
			if (useLaser) {
				impactEffect.Stop();
				lineRenderer.enabled = false;
				impactLight.enabled = false;
			}
			return;
		}

		lockOnTartget();
		if (useLaser) {
			laser();
		} else {
			if (fireCountdown <= 0) {
				Shoot();
				fireCountdown = 1f / fireRate;
			}
			fireCountdown -= Time.deltaTime;
		}
	}

	private void laser() {
		if (!lineRenderer.enabled) {
			lineRenderer.enabled = true;
			impactEffect.Play();
			impactLight.enabled = true;
		}
		enemy.slow(slowPercent);
		enemy.takeDamage(damageOverTime * Time.deltaTime);
		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, target.position);

		Vector3 dir = firePoint.position - target.position;
		impactEffect.transform.rotation = Quaternion.LookRotation(dir);
		impactEffect.transform.position = target.position + dir.normalized * 1f;
	}

	private void lockOnTartget() {
		Vector3 direction = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0, rotation.y, 0);
	}

	private void Shoot() {
		GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGo.GetComponent<Bullet>();
		if (bullet != null) {
			bullet.seek(target);
		}
	}

	void UpdateTarget() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (shortestDistance > distanceToEnemy) {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}
		if (shortestDistance <= range) {
			target = nearestEnemy.transform;
			enemy = nearestEnemy.GetComponent<Enemy>();
		} else
			target = null;
	}

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}