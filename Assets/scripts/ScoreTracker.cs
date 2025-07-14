using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    int score = 0;
    public TMP_Text ScoreText;

    void Scored()
    {
        ScoreText.text = "" + score.ToString();
    }

    public void Small_Scored()
    {
        score++;
        Scored();
    }

    public void Big_Scored()
    {
        score += 2; // Assuming big circles give double points
        Scored();
    }

    public void Giant_Scored()
    {
        score += 4; // Assuming giant circles give quadruple points
        Scored();
    }
}
