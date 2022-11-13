using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float speedIncreaseCoef;
    Vector3 pos;
    Vector3 lrc;

    float iSpeed;

    void Awake()
    {
        iSpeed = speed;
    }

    void Update()
    {
        speed = iSpeed + (FindObjectOfType<movement>().realFrame() *speedIncreaseCoef * .0000001f);
        pos = GameObject.Find("Player").transform.position;
        lrc = FindObjectOfType<movement>().lastRC();
        if (Vector3.Distance(transform.position, pos) < Vector3.Distance(transform.position, lrc) || Vector3.Distance(transform.position, pos) < 2.5f)
        {
            if (Vector3.Distance(transform.position, lrc) != 0) {
                Vector3 lookDirection = pos - transform.position;
                float angle = Mathf.Atan2(lookDirection.y, lookDirection.x);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle * Mathf.Rad2Deg - 90f);
                transform.position = new Vector3(transform.position.x + Mathf.Cos(angle) * speed, transform.position.y + Mathf.Sin(angle) * speed, 0f);
            }
        }
        else
        {
            Vector3 lookDirection = lrc - transform.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle * Mathf.Rad2Deg - 90f);
            transform.position = new Vector3(transform.position.x + Mathf.Cos(angle) * speed, transform.position.y + Mathf.Sin(angle) * speed, 0f);
        }
    }
}
