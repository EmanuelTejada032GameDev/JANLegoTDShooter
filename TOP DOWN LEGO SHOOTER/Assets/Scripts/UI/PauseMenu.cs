using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private AudioSource _gameMenuAudioSource;

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        _gameMenuAudioSource.Play();
        SceneManager.LoadScene("StartMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
        {
            _gameMenuAudioSource.Play();
            PauseGame();
        }
    }

    public void PauseGame()
    {
        _gameMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        _gameMenuAudioSource.Play();
        _gameMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        _gameMenuAudioSource.Play();
        Application.Quit();
    }
}
