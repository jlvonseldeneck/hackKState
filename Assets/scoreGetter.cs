using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreGetter : MonoBehaviour
{
    public Text score;

    void Awake()
    {
        score.text = scoring.score.ToString();
    }
}
