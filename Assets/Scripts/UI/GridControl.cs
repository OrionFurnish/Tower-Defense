using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridControl : MonoBehaviour {
    public static bool gridActive = false;
    public Material mat;

    private int gridActiveInt;

    private void Update() {
        gridActiveInt = gridActive ? 1 : 0;
        SetMatInfo(mat);
    }

    private void SetMatInfo(Material material) {
        material.SetInt("_ShowGrid", gridActiveInt);
        if (gridActive) {
            /**if (CombatManager.GetCurrentController() != null) {
                material.SetVector("_SelectedUnitPosition", CombatManager.GetCurrentController().transform.position);
            }*/
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(mousePos.x, mousePos.y, 0f);
            material.SetVector("_MousePos", mousePos);
        }
    }
}
