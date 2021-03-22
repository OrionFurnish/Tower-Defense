using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [HideInInspector] public Path route;
    [HideInInspector] public BarControl barControl;
    public Vector3 barOffset;
    private Waypoint[] myPathThroughLife;
    public int coinWorth;
    public float maxHealth;
    public float speed = .25f;
    private int index = 0;
    private Vector3 nextWaypoint;
    private bool stop = false;
    private float health;

    void Start() {
        myPathThroughLife = route.path;
        transform.position = myPathThroughLife[index].transform.position;
        Recalculate();
        health = maxHealth;
        barControl.Set(health, maxHealth);
        // Setup Bar Follow
        barControl.GetComponent<Follow>().target = transform;
        barControl.GetComponent<Follow>().barOffset = barOffset;
    }

    void Update() {
        if (!stop) {
            if ((transform.position - myPathThroughLife[index + 1].transform.position).magnitude < .1f) {
                index = index + 1;
                Recalculate();
            }

            Vector3 moveThisFrame = nextWaypoint * Time.deltaTime * speed;
            transform.Translate(moveThisFrame);
        }

    }

    public void TakeDamage(float damage) {
        health -= damage;
        barControl.Set(health, maxHealth);
        if(health <= 0f) {
            Resources.AddCoins(coinWorth);
            Destroy(barControl.gameObject);
            Destroy(gameObject);
        }
    }

    void Recalculate() {
        if (index < myPathThroughLife.Length - 1) {
            nextWaypoint = (myPathThroughLife[index + 1].transform.position - myPathThroughLife[index].transform.position).normalized;

        } else { stop = true; }
    }
}
