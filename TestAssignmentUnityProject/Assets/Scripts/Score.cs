using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static TextMeshProUGUI scoreText;
    public static int score;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public static void AddScore()
    {
        score += 1;
        scoreText.text = $"Score: {score}";
    }
}
