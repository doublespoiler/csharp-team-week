using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Typed By: Sam Majerus, 10/31/2022. 
//Resource used:  https://levelup.gitconnected.com/how-to-create-an-enemy-wave-system-in-unity-49c5328564e7 

// [NTS:  May need to replace 'WaitForSeconds' with 'DeltaTime']




/* 
private SpawnManager _spawnManager; 
private UIManager _uiManager; 
// private WaveManager _waveManager; 

public int currentWave = 1; 
public int enemiesToSpawn = 5;
public int enemiesLeft = 0; 
//Timer that increments by 20 seconds for every enemy eliminated. 

public bool StartOfWave; 

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
  StartCorountine(StartWaveRoutine());
}

IEnumerator StartWaveRoutine()
{
  _uiManager.UpdateWaveStartDisplay(currentWave); 
  yield return new WaitForSeconds(3f);  //Wait 3.0 seconds before doing the if-statement check 

  if (enemiesLeft != enemiesToSpawn)
  {
    _spawnManager.StartSpawning(); 
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



//"Inside UI Manager script.." ('Update UI Show Wave', Step 1). 
[SerializeField]
private TextMeshProUGUI _waveCounter; 

public void UpdateWaveStartDisplay(int currentWave)
{
  _waveCounter.gameObject.SetActive(true); 
  _waveCounter.text = "Wave: " + currentWave; 
  StartCoroutine(BlinkGameObject(_waveCounter.gameObject, 2, .7f, false));
}



//"Spawning the Enemies:" 
IEnumerator SpawnEnemyRoutine()
{
  int enemiesSpawned = 0; 
  yield return new WaitForSeconds(3.0f);

  while (_stopSpawning != true)
  {
    if(enemiesSpawned != _waveManager.enemiesToSpawn)
    {
      if(_waveManager.currentWave < 5)
      {
        GameObject newEnemy = Instantiate(_enemyPrefabs[0], RandomPos(), Quaternion.identity); 

        newEnemy.transform.parent = _enemyContainer.transform; 

        _waveManager.enemiesLeft++; 
        enemiesSpawned++; 
      }
      else if (_waveManager.currentWave >= 5)
      {
        int randomEnemyID = Random.Range(0, 2); 

        GameObject newEnemy = Instantiate(_enemyPrefabs[0], RandomPos(), Quaternion.identity); 

        newEnemy.transform.parent = _enemyContainer.transform; 

        _waveManager.enemiesLeft++; 
        enemiesSpawned++; 
      }
    }
    else
    {
      _waveManager.startOfWave = false; 
      enemiesSpawned = 0; 
      StopSpawning(); 
    }

    yield return new WaitForSeconds(3f); 
  }
}


*/