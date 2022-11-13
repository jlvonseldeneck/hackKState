using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightSpriteContoller : MonoBehaviour
{
    void Update() {
      
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 1f;
            transform.position = mousePos;
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Middle Click");
        }
    }
}
