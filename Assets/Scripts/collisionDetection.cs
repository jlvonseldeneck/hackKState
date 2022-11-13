using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    public static int score;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "wall")
        {
            Destroy(gameObject);
            FindObjectOfType<AudioHandler>().resetExpPitch();
        }
        else if (col.gameObject.tag == "enemy")
        {
            FindObjectOfType<AudioHandler>().playExplosion();
            FindObjectOfType<AudioHandler>().pitchUpExp();
            FindObjectOfType<shooting>().addAmmo();
            if (col.gameObject.name == "E1")
            {
                //
            }
            else if (col.gameObject.name == "E2")
            {
                //
            }
            else if (col.gameObject.name == "E3")
            {
                //
            }
            Destroy(gameObject);
            Destroy(col.gameObject);
        }

    }
}
