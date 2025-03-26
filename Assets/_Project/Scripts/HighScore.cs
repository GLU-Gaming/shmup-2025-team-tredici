using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HighScore : MonoBehaviour
{
    private int HighestScore = 0;
    [SerializeField] private TextMeshProUGUI Highscore;

    void Start()
    {
        if (GameManager.FinalScore > HighestScore || HighestScore == 0)
        {
            HighestScore = GameManager.FinalScore;
        }
    }

    void Update()
    {
        Highscore.text = "score:" + HighestScore;
    }
}
