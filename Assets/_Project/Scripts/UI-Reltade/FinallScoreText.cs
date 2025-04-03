using TMPro;
using UnityEngine;

public class FinallScoreText : MonoBehaviour
{
    private int Currentscore;
    [SerializeField] private TextMeshProUGUI Text;
    void Start()
    {
        Currentscore = PlayerPrefs.GetInt("CurrentScore", 0);
    }

    void Update()
    {
        Text.text = "Score:" + Currentscore;
    }
}
