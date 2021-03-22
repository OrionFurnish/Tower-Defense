using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour {
    public static Resources instance;
    public TextMeshProUGUI coinsText;
    private static int coins;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(instance.gameObject);
        }
    }

    public static void AddCoins(int amount) {
        coins += amount;
        instance.coinsText.text = "Coins: " + coins.ToString();
    }

    public static bool SpendCoins(int amount) {
        if(coins - amount > 0) {
            coins -= amount;
            instance.coinsText.text = "Coins: " + coins.ToString();
            return true;
        } else {
            return false;
        }
    }
}
