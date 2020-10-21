using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public static TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public static void AddToScore(int points)
    {
        ApplicationModel.Score += points;
        _text.text = ApplicationModel.Score.ToString("d8");
    }
}
