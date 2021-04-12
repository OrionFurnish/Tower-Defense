using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public TextMeshProUGUI coinsText, lifeText;
    private static int coins, life;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(instance.gameObject);
        }

        SetCoins(100);
        SetLife(5);
    }

    private static void SetCoins(int amount) {
        coins = amount;
        if (instance.coinsText != null) {
            instance.coinsText.text = "Coins: " + coins.ToString();
        }
    }

    private static void SetLife(int amount) {
        life = amount;
        if (instance.coinsText != null) {
            instance.lifeText.text = "Life: " + life.ToString();
        }
    }

    public static void AddCoins(int amount) {
        coins += amount;
        instance.coinsText.text = "Coins: " + coins.ToString();
    }

    public static bool SpendCoins(int amount) {
        if(coins - amount >= 0) {
            coins -= amount;
            instance.coinsText.text = "Coins: " + coins.ToString();
            return true;
        } else {
            return false;
        }
    }

    public static void AdjustLife(int amount) {
        life += amount;
        instance.lifeText.text = "Life: " + life.ToString();
        if (life <= 0) {
            instance.EndGame();
        }
    }

    private void EndGame() {
        SceneManager.LoadScene("End Scene");
    }

    public void StartGame() {
        SceneManager.LoadScene("Game Scene");
    }
}
