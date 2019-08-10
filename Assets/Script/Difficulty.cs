using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadDifficulty()
    {
        SceneManager.LoadScene(1);
    }

    public void Chill()
    {
        SceneManager.LoadScene(2);
    }

    public void Challenging()
    {
        SceneManager.LoadScene(6);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene(2);
    }
}
