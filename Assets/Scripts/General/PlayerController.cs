using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {
    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            if(!EventSystem.current.IsPointerOverGameObject()) {
                BuildMenu.CloseMenu();
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit)) {
                    TowerLocation towerLocation = hit.collider.gameObject.GetComponent<TowerLocation>();
                    if (towerLocation != null) {
                        towerLocation.OpenMenu();
                    }
                }
            }
        }
    }
}
