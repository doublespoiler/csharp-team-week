using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

//Created by: Sam Majerus, 10/31/2022. 
//Resource used:  https://levelup.gitconnected.com/how-to-create-an-enemy-wave-system-in-unity-49c5328564e7 

// [NTS:  May need to replace 'WaitForSeconds' with 'DeltaTime']

public class EnemyWaves : MonoBehaviour
{
  [field: SerializeField]
  private SpawnManager _spawnManager; 
  [field: SerializeField]
  private UIManager _uiManager; //do this on the enemy & uimanager.updatescore 
  // private WaveManager _waveManager; 

  public int currentWave = 1; 
  public int enemiesToSpawn = 5;
  public int enemiesLeft = 0; 
  public int enemiesSpawned = 0;
  private int playerScore;
  //Timer that increments by 10 seconds for every enemy eliminated. 

  public bool startOfWave; 
  private bool _stopSpawning;

  void Start() 
  {
    _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>(); 
    if (_uiManager == null) {
      Debug.LogError("Game Canvas is Null!!");
    }
    playerScore = 0;
    _spawnManager = GetComponent<SpawnManager>();
  }

  void Update()
  {
    // Debug.Log("Enemies remaining: " + enemiesLeft);
    // _uiManager.UpdateEnemiesLeft(enemiesLeft);
    
    if (enemiesLeft <= 0 && startOfWave != true)
    {
      enemiesLeft = 0; 
      EndWave();
    }
  }

  public void StartWave()
  {
    Debug.Log("Starting wave " + currentWave);
    startOfWave = true;
    StartCoroutine(StartWaveRoutine());
  }

  IEnumerator StartWaveRoutine()
  {
      Debug.Log("Starting wave coroutine....");
    // _uiManager.UpdateEnemiesToSpawn(enemiesToSpawn);
    _uiManager.UpdateWaveStartDisplay(currentWave); 
    yield return new WaitForSeconds(1f);  //Wait 3.0 seconds before doing the if-statement check 

    if (enemiesSpawned < enemiesToSpawn)
    {
      _spawnManager.SpawnEnemy(); 
    }
  }

  public void EndWave()
  {
        Debug.Log("Ending wave");

    StartCoroutine(EndWaveRoutine());
  }

  IEnumerator EndWaveRoutine()
  {
    Debug.Log("Ending wave coroutine....");
    startOfWave = true;
    currentWave++; 
    Debug.Log("New wave " + currentWave);
    enemiesToSpawn += 3; 
    enemiesSpawned = 0;
    yield return new WaitForSeconds(2.5f);  //Wait 2.5 seconds to call 'StartWave' method
    StartWave();
  }

  public void UpdateScore()
  {
    playerScore += currentWave;
    _uiManager.UpdateScoreDisplay(playerScore);
  }
}
