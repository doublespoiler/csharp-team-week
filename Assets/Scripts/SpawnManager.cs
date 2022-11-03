using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{

    [field:SerializeField]
    private bool _stopSpawning;
    private GameObject _enemyContainer;
    [field:SerializeField]
    private EnemyWaves _waveManager;
    [field:SerializeField]
    private GameObject _enemyPrefab;
    [field:SerializeField]
    private float spawnDelay = 1f;
    List<Bounds> spawnBounds = new List<Bounds>{};
    public int enemiesSpawned {get; private set;}
    private Bounds bounds;

    void Start()
    {
      _enemyContainer = GameObject.Find("EnemyContainer");
      GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
      
      foreach(GameObject area in spawnPoints)
      {
        spawnBounds.Add(area.GetComponent<Renderer>().bounds);
      }
      enemiesSpawned = 0;
      StartCoroutine(SpawnEnemy());
    }

    //"Spawning the Enemies:" 
  public IEnumerator SpawnEnemy()
  {
    Debug.Log("Spawning enemies coroutine");
    yield return new WaitForSeconds(3.0f);

    while (!_stopSpawning)
    {
      if(_waveManager.enemiesSpawned < _waveManager.enemiesToSpawn)
      {
        //Can DRY this if needed. -SM
            bounds = RandomBounds();
            Debug.Log(bounds.size);
            Debug.Log(bounds);
            Vector3 position = bounds.center + RandomPos(bounds);
            Debug.Log("Spawning enemy " + (_waveManager.enemiesSpawned + 1) + " of " + _waveManager.enemiesToSpawn + " at " + position);
            GameObject newEnemy = Instantiate(_enemyPrefab, position, Quaternion.identity, _enemyContainer.transform);
            _waveManager.enemiesLeft++; 
            _waveManager.enemiesSpawned++; 
            yield return new WaitForSeconds(spawnDelay);
        
        // else if (_waveManager.currentWave >= 5)
        // {
        //   Debug.Log("63");
        //   GameObject newEnemy = Instantiate(_enemyPrefab, RandomPos(), Quaternion.identity); 
        //   newEnemy.transform.parent = _enemyContainer.transform; 
        //   _waveManager.enemiesLeft++; 
        //   enemiesSpawned++; 
        // }
      }
      else
      {
        // Debug.Log("done spawning");
        _waveManager.startOfWave = false; 
      }

      yield return new WaitForSeconds(1f); 
    }
  }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomPos(Bounds incB)
    {
      float offsetX = Random.Range(-incB.extents.x, incB.extents.x);
      float offsetY = Random.Range(-incB.extents.y, incB.extents.y);
      float offsetZ = Random.Range(-incB.extents.z, incB.extents.z);
      return new Vector3(offsetX , offsetY, offsetY);
    }
    
    Bounds RandomBounds()
    {
      return spawnBounds[Random.Range(0, spawnBounds.Count - 1)];
    }
}
