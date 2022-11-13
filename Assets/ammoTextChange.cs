using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ammoTextChange : MonoBehaviour
{
    public Text txt;

    void Update()
    {
        txt.text = FindObjectOfType<shooting>().getAmmo().ToString();
    }
}
