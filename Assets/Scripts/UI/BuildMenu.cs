using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildMenu : MonoBehaviour {
    public static BuildMenu instance;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        gameObject.SetActive(false);
    }

    public GameObject descriptionObj;
    public TextMeshProUGUI titleText, costText, descriptionText;

    private TowerLocation selectedLocation;
    private GameObject selectedTower;

    public void UpdateDescription(GameObject towerObj) {
        descriptionObj.SetActive(true);
        Tower towerInfo = towerObj.GetComponent<Tower>();
        titleText.text = towerInfo.towerName;
        costText.text = "Cost: " + towerInfo.goldCost + " Gold";
        descriptionText.text = towerInfo.description;
        selectedTower = towerObj;
    }

    public void BuildTower() {
        if(selectedTower != null && selectedLocation != null) {
            // Spend Resources
            if(GameManager.SpendCoins(selectedTower.GetComponent<Tower>().goldCost)) {
                // Build
                selectedLocation.BuildTower(selectedTower);
                CloseMenu();
            } else {
                Debug.Log("Not enough gold to build tower");
            }
        }
    }

    public void SetLocation(TowerLocation towerLocation) {
        selectedLocation = towerLocation;
    }

    public static void CloseMenu() {
        instance.gameObject.SetActive(false);
        instance.descriptionObj.SetActive(false);
    }
}
