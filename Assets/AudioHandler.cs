using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioSource explosion;
    public AudioSource shoot;
    public AudioSource engine;
    public AudioSource combo;
    public AudioSource playerDeath;

    public int expPitchUp = 0;
    public float startingExpPitch;

    void Awake() {
        startingExpPitch = explosion.pitch;
    }

    public void playShoot() {
        shoot.Play();
    }

    public void gameOver()
    {
        Debug.Log("Play");
        playerDeath.Play();
    }


    public void playExplosion()
    {
        explosion.Play();
    }

    public void playEngine()
    {
        engine.Play();
    }

    public void pitchUpExp() {
        explosion.pitch += 1f;
        expPitchUp++;
        if (expPitchUp == 8) {
            explosion.pitch = startingExpPitch;
            expPitchUp = 0;
            Debug.Log("Combo!");

        }
    }

    public void resetExpPitch() {
        explosion.pitch = startingExpPitch;
        expPitchUp = 0;
    }
}
