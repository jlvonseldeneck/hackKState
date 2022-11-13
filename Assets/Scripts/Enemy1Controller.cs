using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    [SerializeField] public float speed;
    Vector3 pos;
    [SerializeField] public float speedIncreaseCoef;
    float iSpeed;

    void Awake() {
        iSpeed = speed;
    }

    void Update()
    {
        speed = iSpeed + (FindObjectOfType<movement>().realFrame() *speedIncreaseCoef * .0000001f);
        pos = GameObject.Find("Player").transform.position;
        Vector3 lookDirection = pos - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle * Mathf.Rad2Deg - 90f);
        transform.position = new Vector3(transform.position.x + Mathf.Cos(angle) * speed, transform.position.y + Mathf.Sin(angle) * speed, 0f);
    }
}
