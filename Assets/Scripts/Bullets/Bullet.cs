using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    GameObject impactParticles = null;
    [SerializeField]
    float explosionRadius = 0f;
    [SerializeField]
    int damage = 50;
    private Transform target;

    public void seek(Transform target) {
        this.target = target;
    }

    public float speed = 70f;

    private void Start() {
        if (impactParticles == null)
            Debug.LogWarning("impact particles not set");
    }

    void Update() {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (direction.magnitude <= distanceThisFrame) {
            hitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void hitTarget() {
        if (impactParticles != null) {
            GameObject effectGO = (GameObject) Instantiate(impactParticles, transform.position, transform.rotation);
            Destroy(effectGO, 2f);
        }
        if (explosionRadius > 0f) {
            explode();
        } else {
            damageTarget(target);
        }
        Destroy(gameObject);
    }

    private void explode() =>
        Physics.OverlapSphere(transform.position, explosionRadius)
        .Where(it => it.tag == "Enemy")
        .ToList()
        .ForEach(it => damageTarget(it.transform));

    private void damageTarget(Transform enemy) {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null) {
            e.takeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}