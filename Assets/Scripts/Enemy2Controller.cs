using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float speedIncreaseCoef;

    public GameObject self;

    Vector3 pos;



    float iSpeed;

    void Awake()
    {
        iSpeed = speed;
        pos = new Vector3((float)Random.Range(-800, 800) / 100f, (float)Random.Range(-500, 500) / 100f, 0f);
    }

    void Update()
    {
        speed = iSpeed + (FindObjectOfType<movement>().realFrame() * speedIncreaseCoef * .0000001f);
        if (Vector3.Distance(transform.position, pos) <= .3f)
        {
            pos = new Vector3((float)Random.Range(-800, 800) / 100f, (float)Random.Range(-500, 500) / 100f, 0f);
        }
        Debug.Log(pos);
        Vector3 lookDirection = pos - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle * Mathf.Rad2Deg - 90f);
        transform.position = new Vector3(transform.position.x + Mathf.Cos(angle) * speed, transform.position.y + Mathf.Sin(angle) * speed, 0f);

    }
}
