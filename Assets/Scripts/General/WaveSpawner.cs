using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public Transform lifeBarPrefab;
    public Transform lifeBarParent;
    public Wave[] waves;

    void Start() {
        StartCoroutine(SpawnWave(waves[0])); // for now just spawn one wave
    }

    IEnumerator SpawnWave(Wave wave) {
        foreach(WaveElement waveElement in wave.waveElements) {
            for(int i = 0; i < waveElement.numberToSpawn; i++) {
                Transform t = Instantiate(waveElement.enemyType, transform);
                Enemy enemy = t.GetComponent<Enemy>();
                enemy.route = waveElement.route;
                enemy.barControl = Instantiate(lifeBarPrefab, lifeBarParent).GetComponent<BarControl>();
                yield return new WaitForSeconds(waveElement.timeTillNextSpawn);
            }
        }
    }
}

[System.Serializable]
public class Wave {
    public WaveElement[] waveElements;
}

[System.Serializable]
public struct WaveElement {
    public Transform enemyType;
    public int numberToSpawn;
    public float timeTillNextSpawn;
    public Path route;
} 
