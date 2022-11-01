using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [field:SerializeField]

    private bool _stopSpawning;
    private Transform _enemyContainer;
    [field:SerializeField]
    private EnemyWaves _waveManager;
    [field:SerializeField]
    private GameObject _enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
      _enemyContainer = transform.GetChild(0);
      StartCoroutine(SpawnEnemy());
    }

    //"Spawning the Enemies:" 
  public IEnumerator SpawnEnemy()
  {
    int enemiesSpawned = 0; 
    yield return new WaitForSeconds(3.0f);

    while (!_stopSpawning)
    {
      
      if(enemiesSpawned != _waveManager.enemiesToSpawn)
      {
        //Can DRY this if needed. -SM
        if(_waveManager.currentWave < 5)
        {
          GameObject newEnemy = Instantiate(_enemyPrefab, RandomPos(), Quaternion.identity); 

          newEnemy.transform.parent = _enemyContainer.transform; 

          _waveManager.enemiesLeft++; 
          enemiesSpawned++; 
        }
        else if (_waveManager.currentWave >= 5)
        {
          GameObject newEnemy = Instantiate(_enemyPrefab, RandomPos(), Quaternion.identity); 
          newEnemy.transform.parent = _enemyContainer.transform; 
          _waveManager.enemiesLeft++; 
          enemiesSpawned++; 
        }
      }
      else
      {
        _waveManager.startOfWave = false; 
        enemiesSpawned = 0; 
      }

      yield return new WaitForSeconds(3f); 
    }
  }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomPos()
    {
      float x = Random.Range(-25, 26);
      int y = 5;
      float z = Random.Range(-25, 26);
      return new Vector3(x, y, z);
    }
}
