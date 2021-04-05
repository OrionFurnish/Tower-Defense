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

    [HideInInspector] public List<Enemy> targets = new List<Enemy>();

    private void Awake() {
        GetComponentsInChildren<SphereCollider>()[1].radius = range;
        StartCoroutine(FireProjectiles());
    }

    private IEnumerator FireProjectiles() {
        while(true) {
            // Remove null targets
            for(int i = 0; i < targets.Count; i++) {
                if(targets[i] == null) {
                    targets.RemoveAt(i);
                    i--;
                }
            }
            if (targets.Count > 0) {
                Enemy target = targets[0];
                // Select furthest along enemy here
                Projectile curProjectile = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Projectile>();
                curProjectile.Initialize(target, projectileSpd, damage);
                yield return new WaitForSeconds(reloadTime);
            } else {
                yield return null;
            }
        }
    }
}
