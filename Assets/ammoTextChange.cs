﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ammoTextChange : MonoBehaviour
{
    public Text ammo;
    public Text score;

    void Update()
    {
        ammo.text = FindObjectOfType<shooting>().getAmmo().ToString();
        score.text = scoring.score.ToString();
    }
}
