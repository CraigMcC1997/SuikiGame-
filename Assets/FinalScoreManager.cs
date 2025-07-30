using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalScoreManager : MonoBehaviour
{
    public TMP_Text currentScoreText;
    public TMP_Text highScoreText;

    public void UpdateHighScoreText()
    {
        highScoreText.text = "Highscore: " + GetHighScore().ToString();
    }

    public void UpdateCurrentScoreText()
    {
        currentScoreText.text = "Current Score: " + GetCurrentScore().ToString();
    }

    void Start()
    {
        UpdateHighScoreText();
        UpdateCurrentScoreText();
    }

    int GetCurrentScore()
    {
        return PlayerPrefs.GetInt("CurrentScore", 0);
    }

    int GetHighScore()
    {
        return PlayerPrefs.GetInt("Highscore", 0);
    }

}
