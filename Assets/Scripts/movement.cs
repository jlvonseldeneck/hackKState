using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{

    [SerializeField] public float speed;

    [SerializeField] public float multi;

    private float aSpeed;

    public GameObject rightSprite;
    Vector3 lastRightClick = new Vector3(0f, 0f, 0f);
    Vector3 currentMousePosition;
    public Animator anim;
    public AudioSource bgmusic;

    bool boom = false;
    int killEnemy;

    int frameCount = 0;

    public Slider slider;

    public int score = 0;

    public int realFrame() {
        return frameCount;
    }

    public bool shouldSpawn() {
        return !boom;
    }

    public Vector3 lastRC()
    {
        return lastRightClick;
    }

    public void addScore(int add) {
        score += add;

    }


    public int getScore()
    {
        return score;
    }

    void Update()
    {
        if (boom) {
            frameCount++;
            if (frameCount == 66) {
                transform.position = new Vector3(-50f, 50f, 0f);
                FindObjectOfType<gameManagerScript>().gameOver(killEnemy);
            }

        }
        else
        { 
            frameCount++;
            slider.value = frameCount % 1000f;
            if (frameCount % 1000f == 0) {
                FindObjectOfType<shooting>().addAmmo();
            }
            if (Input.GetMouseButtonDown(1))
            {
                lastRightClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                lastRightClick.z = 0f;
                FindObjectOfType<AudioHandler>().playEngine();
            }

            currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePosition.z = 0f;
            float xDiff = lastRightClick.x - transform.position.x;
            float yDiff = lastRightClick.y - transform.position.y;
            if (Mathf.Abs(xDiff) > 0 || Mathf.Abs(yDiff) > 0)
            {
                int ammo = FindObjectOfType<shooting>().getAmmo();
                if (ammo < 5)
                {
                    aSpeed = speed + (5 - ammo)/multi;
                }
                else {
                    aSpeed = speed;
                }
                float hypot = Mathf.Sqrt(Mathf.Pow(xDiff, 2) + Mathf.Pow(yDiff, 2));
                if (hypot <= aSpeed)
                {
                    anim.SetBool("walking", false);
                    transform.position = lastRightClick;
                }
                else
                {
                    anim.SetBool("walking", true);
                    Vector3 lookDirection2 = lastRightClick - transform.position;
                    float angle2 = Mathf.Atan2(lookDirection2.y, lookDirection2.x);
                    transform.position = new Vector3(transform.position.x + Mathf.Cos(angle2) * aSpeed, transform.position.y + Mathf.Sin(angle2) * aSpeed, 0f);
                }
            }
            Vector3 lookDirection = currentMousePosition - transform.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle * Mathf.Rad2Deg - 90f);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            bgmusic.mute = true;
            FindObjectOfType<AudioHandler>().gameOver();
            rightSprite.transform.position = new Vector3(-50f, 50f, 0f);
            lastRightClick = new Vector3(-50f, 50f, 0f);
            anim.SetBool("boom", true);
            boom = true;
            frameCount = 0;
            killEnemy = 1;
        }
    }
}
