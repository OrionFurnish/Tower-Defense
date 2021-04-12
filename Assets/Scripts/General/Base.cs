using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.gameObject.CompareTag("Enemy")) {
            GameManager.AdjustLife(-1);
            collision.collider.gameObject.GetComponent<Enemy>().Remove();
        }
    }
}
