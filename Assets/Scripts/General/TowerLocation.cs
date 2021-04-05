using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLocation : MonoBehaviour {
    public Vector3 menuOffset;
    private GameObject tower;

    public void OpenMenu() {
        if (tower == null) {
            // Setup Build Menu
            BuildMenu.instance.gameObject.SetActive(true);
            BuildMenu.instance.transform.position = Camera.main.WorldToScreenPoint(transform.position + menuOffset);
            BuildMenu.instance.SetLocation(this);
        } else {
            // Setup Tower Menu
        }
    }

    public void BuildTower(GameObject tower) {
        this.tower = Instantiate(tower, transform);
        this.tower.transform.localPosition = Vector3.zero;
    }
}
