using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Collider2D[] hits = Physics2D.OverlapPointAll(GetMousePos());
            foreach (Collider2D hit in hits) {
                if (hit != null) {
                    Enemy enemy = hit.gameObject.GetComponent<Enemy>();
                    if(enemy != null) {
                        enemy.TakeDamage(1f);
                    }
                }
            }
        }
    }

    private Vector3 GetMousePos() {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }
}
