using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonAudioSource;
    public void StartGame()
    {
        StartCoroutine("PlayClipSound");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        StartCoroutine("PlayClipSound");
        Application.Quit();
    }

    IEnumerator PlayClipSound()
    {
        _buttonAudioSource.Play();
        yield return new WaitForSeconds(2);

    }
}
