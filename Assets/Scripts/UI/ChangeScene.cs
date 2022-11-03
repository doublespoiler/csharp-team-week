using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Link to resource used for Pause Menu:  https://www.youtube.com/watch?v=JivuXdrIHK0  

public class ChangeScene : MonoBehaviour
{
  public void MoveToScene(int sceneId) //Link to resource used:  https://www.youtube.com/watch?v=EMo-MaKkP9s 
  {
    Time.timeScale = 1f;
    if(sceneId == 1)
    {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }
    else
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }
    SceneManager.LoadScene(sceneId); 
  }
}
