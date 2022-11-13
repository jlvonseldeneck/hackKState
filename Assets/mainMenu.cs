using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class mainMenu : MonoBehaviour
{
    public AudioMixer am;

    public void SetVolume(float volume) {
        am.SetFloat("volume", volume);
    }

    public void PlayGame() {
        scoring.score = 0;
        SceneManager.LoadScene(1);
    }

    public void QuitButton() {
        Application.Quit();
    }
}
