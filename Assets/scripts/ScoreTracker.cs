using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

enum CircleType
{
    Cherry = 1,
    Strawberry = 2,
    Grape = 4,
    Dekopon = 8,
    Orange = 16,
    Apple = 32,
    Pear = 64,
    Peach = 128,
    Pineapple = 256,
    Melon = 512,
    Watermelon = 1024,
}

public class ScoreTracker : MonoBehaviour
{
    int score = 0;
    public TMP_Text ScoreText;

    void UpdateScoreText()
    {
        ScoreText.text = "" + score.ToString();
    }

    /** Take the tag for the two fruits colliding, use that to get the Score from the above enum,
     *  Add the score to the total score, and update the UI text.
     */
    public void Scored(string tag)
    {
        CircleType scoreValue = (CircleType)Enum.Parse(typeof(CircleType), tag);
        score += (int)scoreValue;
        UpdateScoreText();
    }
}
