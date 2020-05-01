using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
	private Transform target;
	private int wavepointIndex = 1;
	private Enemy enemy;
	private NavMeshAgent navMeshAgent;

	private void Start() {
		navMeshAgent = GetComponent<NavMeshAgent>();
		enemy = GetComponent<Enemy>();
		navMeshAgent.destination = LevelInfo.Instance.endPoint.position;
		navMeshAgent.updatePosition = true;
		navMeshAgent.updateRotation = true;
	}

	void Update() {
		if (navMeshAgent.remainingDistance < 1.0f)
			endPath();
		navMeshAgent.speed = enemy.speed;
	}

	private void endPath() {
		Destroy(gameObject);
		PlayerStats.takeLive();
		WaveSpawner.enemiesAlive--;
	}

}