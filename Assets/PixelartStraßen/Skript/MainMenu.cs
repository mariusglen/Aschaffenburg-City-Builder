using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {       
        //AudioManager2.Instance.PlaySFX("Pop");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    /*public void GoToNewGame()
    {
        SceneManager.LoadScene("SpielScene");
    }*/

    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
        AudioManager2.Instance.PlaySFX("Pop");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        AudioManager2.Instance.PlaySFX("Pop");
    }

    public void QuitGame()
    {
        Application.Quit();
        AudioManager2.Instance.PlaySFX("Pop");
    }
}
