using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour {
    Tower tower;

    private void Awake() {
        tower = GetComponentInParent<Tower>();
    }

    public void OnTriggerEnter(Collider coll) {
        Enemy enemy = coll.GetComponent<Enemy>();
        if (enemy != null) {
            tower.targets.Add(enemy);
        }
    }

    public void OnTriggerExit(Collider coll) {
        Enemy enemy = coll.GetComponent<Enemy>();
        if (enemy != null) {
            tower.targets.Remove(enemy);
        }
    }
}
