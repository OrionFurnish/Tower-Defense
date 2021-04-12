using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Enemy : MonoBehaviour {
    [HideInInspector] public Path route;
    [HideInInspector] public BarControl barControl;
    public Vector3 barOffset;
    private Waypoint[] myPathThroughLife;
    public int coinWorth;
    public float maxHealth;
    public float speed = .25f;
    public float waypointAccuracy = 1f;
    public UnityEvent deathEvent = new UnityEvent();
    public GameObject textFloatPrefab;
    private int index = 0;
    private Waypoint nextWaypoint;
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
            if ((transform.position - myPathThroughLife[index + 1].transform.position).magnitude < waypointAccuracy) {
                index = index + 1;
                Recalculate();
            }

            Vector3 moveThisFrame = (nextWaypoint.transform.position - transform.position).normalized * Time.deltaTime * speed;
            transform.Translate(moveThisFrame);
        }

    }

    public void TakeDamage(float damage) {
        if(health > 0f) {
            health -= damage;
            barControl.Set(health, maxHealth);
            if (health <= 0f) {
                Die();
            }
        }
    }

    void Recalculate() {
        if (index < myPathThroughLife.Length - 1) {
            nextWaypoint = myPathThroughLife[index + 1];

        } else { stop = true; }
    }

    public void Die() {
        GameManager.AddCoins(coinWorth);
        GameObject obj = Instantiate(textFloatPrefab, barControl.transform.parent);
        obj.transform.position = transform.position;
        obj.GetComponent<TextMeshProUGUI>().text = "+" + coinWorth + " Gold";
        GetComponent<AudioSource>().Play();
        Remove();
    }

    public void Remove() {
        Destroy(barControl.gameObject);
        deathEvent.Invoke();
        GetComponent<MeshRenderer>().enabled = false;
        Invoke("DestroySelf", .3f);
    }

    private void DestroySelf() {
        Destroy(gameObject);
    }
}
