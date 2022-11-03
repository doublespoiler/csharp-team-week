using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _waveCounter; 
    [SerializeField]
    private TextMeshProUGUI _scoreCounter;
    [SerializeField]
    private TextMeshProUGUI _ammoCounter;
    [SerializeField]
    private GameObject _gameOverUi;
    // private TextMeshProUGUI _enemiesLeft;
    // [SerializeField]
    // private TextMeshProUGUI _enemiesToSpawn;
    // Start is called before the first frame update
    void Start()
    {
      _gameOverUi = GameObject.Find("GameOverU");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      //"Inside UI Manager script.." ('Update UI Show Wave', Step 1). 


  public void UpdateWaveStartDisplay(int currentWave)
  {
    _waveCounter.gameObject.SetActive(true); 
    _waveCounter.text = "Wave: " + currentWave; 
  }

  public void UpdateScoreDisplay(int score)
  {
    _scoreCounter.text = "Score: " + score;
  }

  public void UpdateAmmoDisplay(int ammo, int maxAmmo)
  {
    _ammoCounter.text = "Ammo: " + ammo + "/" + maxAmmo;
  }

  // public void UpdateEnemiesToSpawn(int enemiesToSpawn)
  // {
  //   _ammoCounter.text = "ToSpawn: " + enemiesToSpawn;
  // }

  // public void UpdateEnemiesLeft(int enemiesLeft)
  // {
  //   _ammoCounter.text = "Left: " + enemiesLeft;
  // }

  public void GameOver()
  {
    Time.timeScale = 0f;
    Debug.Log("Playing Game Over");
      Cursor.visible = true;  //Shows cursor
      Cursor.lockState = CursorLockMode.None;
      _gameOverUi.SetActive(true);
  }
}
