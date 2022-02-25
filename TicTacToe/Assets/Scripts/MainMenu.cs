using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public void Awake()
    {
        pauseMenu.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
        
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);

    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
    }
    
     
}
