using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

//Typed By: Sam Majerus, 10/31/2022. 
//Resource used:  https://levelup.gitconnected.com/how-to-create-an-enemy-wave-system-in-unity-49c5328564e7 

// [NTS:  May need to replace 'WaitForSeconds' with 'DeltaTime']

public class EnemyWaves : MonoBehaviour
{
  [field: SerializeField]
  private SpawnManager _spawnManager; 
  [field: SerializeField]
  private UIManager _uiManager; 
  // private WaveManager _waveManager; 

  public int currentWave = 1; 
  public int enemiesToSpawn = 5;
  public int enemiesLeft = 0; 
  //Timer that increments by 10 seconds for every enemy eliminated. 

  public bool startOfWave; 
  private bool _stopSpawning;

  void Start() 
  {
    _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>(); 
    if (_uiManager == null) {
      Debug.LogError("Game Canvas is Null!!");
    }

    _spawnManager = GetComponent<SpawnManager>();
  }

  void Update()
  {
    if (enemiesLeft <= 0 && startOfWave != true)
    {
      enemiesLeft = 0; 
      EndWave();
    }
  }

  public void StartWave()
  {
    startOfWave = true; 
    StartCoroutine(StartWaveRoutine());
  }

  IEnumerator StartWaveRoutine()
  {
    _uiManager.UpdateWaveStartDisplay(currentWave); 
    yield return new WaitForSeconds(3f);  //Wait 3.0 seconds before doing the if-statement check 

    if (enemiesLeft != enemiesToSpawn)
    {
      _spawnManager.SpawnEnemy(); 
    }
  }

  public void EndWave()
  {
    StartCoroutine(EndWaveRoutine());
  }

  IEnumerator EndWaveRoutine()
  {
    startOfWave = true;
    currentWave++; 
    enemiesToSpawn += 5; 
    yield return new WaitForSeconds(2.5f);  //Wait 2.5 seconds to call 'StartWave' method
    StartWave();
  }


  
}
