using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
    private Transform target;
    private int wavepointIndex = 1;
    private Enemy enemy;
    private void Start() {
        target = Waypoints.waypoints[wavepointIndex];
        enemy = GetComponent<Enemy>();
    }

    void Update() {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);
        if (direction.magnitude <= 0.2f) {
            getNextWaypoint();
        }
        
        enemy.speed = enemy.startSpeed;
    }

    private void getNextWaypoint() {
        wavepointIndex++;
        if (wavepointIndex >= Waypoints.waypoints.Length) {
            endPath();
            return;
        }
        target = Waypoints.waypoints[wavepointIndex];
    }

    private void endPath() {
        Destroy(gameObject);
		PlayerStats.takeLive();
		WaveSpawner.enemiesAlive--;
    }

}