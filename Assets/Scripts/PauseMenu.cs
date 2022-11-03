using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Link to resource used for Pause Menu:  https://www.youtube.com/watch?v=JivuXdrIHK0  
//Link to resource used for 'locking/unlocking'- and 'hiding/showing'- mouse cursor:  https://answers.unity.com/questions/1743429/need-help-with-pause-menu-and-cursor-lock-script-c.html  

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false; 

    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(IsPaused)  //if 'IsPaused == true'
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;  //Hides cursor
        Cursor.lockState = CursorLockMode.Locked;  //Locks cursor 
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;   
    }

    void Pause()
    {
        Cursor.visible = true;  //Shows cursor
        Cursor.lockState = CursorLockMode.None;  //Unlocks cursor 
        PauseMenuUI.SetActive(true); 
        Time.timeScale = 0f; //Freezes time, and thus, the game. 
        IsPaused = true; 
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
