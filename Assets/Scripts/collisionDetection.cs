using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    public int e1c = 0;
    public int e2c = 0;
    public int e3c = 0;

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
            if (col.gameObject.name == "E1(Clone)")
            {
                scoring.score += 5;
                e1c++;
            }
            else if (col.gameObject.name == "E2(Clone)")
            {
                scoring.score += 20;
                e2c++;
            }
            else if (col.gameObject.name == "E3(Clone)")
            {
                scoring.score += 10;
                e3c++;
            }
            
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }

    public int gete1c()
    {
        return e1c;
    }
    public int gete2c()
    {
        return e2c;
    }
    public int gete3c()
    {
        return e3c;
    }
}
