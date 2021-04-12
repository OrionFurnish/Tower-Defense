using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    public string towerName;
    public string description;
    public int goldCost;
    public float reloadTime;
    public float damage;
    public float range;
    public GameObject projectile;
    public float projectileSpd;

    public List<Enemy> targets = new List<Enemy>();
    Enemy target;

    private void Awake() {
        GetComponentsInChildren<SphereCollider>()[1].radius = range;
        StartCoroutine(FireProjectiles());
    }

    private void SelectTarget() {
        if(targets.Count > 0) {
            target = targets[0];
            target.deathEvent.AddListener(delegate { SelectTarget(); });
        }
    }

    private IEnumerator FireProjectiles() {
        while(true) {
            if (targets.Count > 0) {
                if(target == null) { SelectTarget(); }
                Projectile curProjectile = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Projectile>();
                curProjectile.Initialize(target, projectileSpd, damage);
                yield return new WaitForSeconds(reloadTime);
            } else {
                yield return null;
            }
        }
    }
}
