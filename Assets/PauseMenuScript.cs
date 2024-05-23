using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        AudioManager2.Instance.PlaySFX("Pop");

    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1;
        AudioManager2.Instance.PlaySFX("Pop");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioManager2.Instance.PlaySFX("Pop");
    }
}
