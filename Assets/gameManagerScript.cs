using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerScript : MonoBehaviour
{
    public void gameOver(int enemy) {
        SceneManager.LoadScene(2);
    }
}
