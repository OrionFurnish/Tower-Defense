using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    Enemy target;
    float speed;
    float damage;

    public void Initialize(Enemy target, float speed, float damage) {
        this.target = target;
        this.speed = speed;
        this.damage = damage;
        Destroy(gameObject, 10f); // Automatically destroy gameobject after 10 seconds
    }

    private void Update() {
        if(target != null) {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        } else {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision) {
        if(collision.gameObject == target.gameObject) {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
