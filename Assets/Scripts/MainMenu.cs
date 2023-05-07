using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public GameOverScreen gameOverScreen;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   
    /*public void RestartGame()
    {
        
    }*/
    public void GoToMainMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");

    }
    public void Quit()
    {
        Application.Quit();
    }
}
