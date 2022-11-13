using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    private int frameCount = 0;
    [SerializeField] public int bgSpeed;
    public float angularSpeed = 1f;
    public float circleRad = 1f;

    private Vector3 fixedPoint;
    private float currentAngle;

    void Start()
    {
        fixedPoint = transform.position;
    }

    void Update()
    {
        frameCount++;
        if (frameCount == bgSpeed)
        {
            frameCount = 0;
            realUpdate();
        }

    }

    void realUpdate()
    {
        currentAngle += angularSpeed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle), 10f / circleRad) * circleRad;
        transform.position = fixedPoint + offset;
    }
}
