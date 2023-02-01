using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private AudioSource _gameMenuAudioSource;
    [SerializeField] Image _cursorCustomImage;


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
        SetCursor(true);
        _gameMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        SetCursor(false);
        _gameMenuAudioSource.Play();
        _gameMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TryAgain()
    {
        SetCursor(false);
        _gameMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        _gameMenuAudioSource.Play();
        Application.Quit();
    }

    public void SetCursor(bool activate)
    {
        if (activate)
        {
            Cursor.visible = true;
            _cursorCustomImage.enabled = false;
        }
        else
        {
            Cursor.visible = false;
            _cursorCustomImage.enabled = true;
        }
    }
}
