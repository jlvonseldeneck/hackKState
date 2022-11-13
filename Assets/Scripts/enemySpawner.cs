using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    private int frameCountUp = 0;
    private float frameCount = 0;
    private float spawnCount = 1;
    [SerializeField] public float frameMax = 10;

    [SerializeField] public float limit;
    [SerializeField] public float start;
    [SerializeField] public float coef;

    public GameObject E1Pref;
    public GameObject E2Pref;
    public GameObject E3Pref;
    public bool spawnEnemies;

    void Awake()
    {
        spawnEnemies = true;
    }

    void Update()
    {
        frameCountUp++;
        spawnEnemies = FindObjectOfType<movement>().shouldSpawn();

        if (frameCountUp >= frameMax && spawnEnemies)
        {
            slowUpdate();
            frameCountUp = 0;
        }
    }

    void slowUpdate() {
        frameCount++;
        if (frameCount >= -(limit / (1 + 5 * Mathf.Exp(coef * spawnCount))) + limit) {
            spawnCount++;
            frameCount = 0;
            Vector3 pos;
            int side = Random.Range(1, 5);
            if (side == 4)
            {
                pos = new Vector3(8.7f, (float)Random.Range(-560,560) / 100f, 0f);
            }
            else if (side == 3)
            {
                pos = new Vector3(-8.7f, (float)Random.Range(-560, 560) / 100f, 0f);
            }
            else if (side == 2)
            {
                pos = new Vector3((float)Random.Range(-870, 870) / 100f, -5.6f, 0f);
            }
            else {
                pos = new Vector3((float)Random.Range(-870, 870) / 100f, -5.6f, 0f);
            }
            int rand = Random.Range(1, 11);
            if (rand > 9)
            {

                GameObject e2 = Instantiate(E2Pref,pos, Quaternion.Euler(0f, 0f, 0f));
                Rigidbody2D rb = e2.GetComponent<Rigidbody2D>();

            }
            else if (rand > 6)
            {
                GameObject e3 = Instantiate(E3Pref, pos, Quaternion.Euler(0f, 0f, 0f));
                Rigidbody2D rb = e3.GetComponent<Rigidbody2D>();
            }
            else {
                GameObject e1 = Instantiate(E1Pref, pos, Quaternion.Euler(0f, 0f, 0f));
                Rigidbody2D rb = e1.GetComponent<Rigidbody2D>();
            }
        }
    }
}
