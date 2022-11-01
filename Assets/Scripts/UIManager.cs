using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _waveCounter; 
    // Start is called before the first frame update
    void Start()
    {
        
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
    StartCoroutine(BlinkGameObject(_waveCounter.gameObject, 2, .7f));
  }

  public IEnumerator BlinkGameObject(GameObject gameObject, int numBlinks, float seconds)
    {
        // In this method it is assumed that your game object has a SpriteRenderer component attached to it
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        // disable animation if any animation is attached to the game object
  //      Animator animator = gameObject.GetComponent<Animator>();
  //      animator.enabled = false; // stop animation for a while
        for (int i = 0; i < numBlinks * 2; i++)
        {
            //toggle renderer
            renderer.enabled = !renderer.enabled;
            //wait for a bit
            yield return new WaitForSeconds(seconds);
        }
        //make sure renderer is enabled when we exit
        renderer.enabled = true;
    //    animator.enabled = true; // enable animation again, if it was disabled before
    }

}
