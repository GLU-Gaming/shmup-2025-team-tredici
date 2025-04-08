using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HighScore : MonoBehaviour
{
    private int HighestScore = 0;
    private int Currentscore;
    [SerializeField] private TextMeshProUGUI Highscore;

    void Start()
    {
        //saves the highscore in a playerprefeb and also gets it
        HighestScore = PlayerPrefs.GetInt("HighestScore", 0);
        Currentscore = PlayerPrefs.GetInt("CurrentScore", 0);
        if (Currentscore > HighestScore)
        {
            HighestScore = Currentscore;
            PlayerPrefs.SetInt("HighestScore", HighestScore);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        Highscore.text = "Highscore:" + HighestScore;
    }
}
