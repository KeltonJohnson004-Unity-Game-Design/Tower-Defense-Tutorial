using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public GameManager gameManager;


    public Transform SpawnPoint;
    public float timeBetweenWaves = 20.5f;
    public Text waveCountdownText;


    private float countdown = 2f;
    private int waveIndex = 0;


    private void Update()
    {
      
        if(EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }


        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    private IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        
        Wave wave = waves[waveIndex];
        EnemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;



    }

    private void SpawnEnemy(GameObject enemy)
    {

        Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
    }
}
