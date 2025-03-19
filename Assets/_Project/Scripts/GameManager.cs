using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextoftheScore;
    public int CurrentScore;
    public int CurrentLifes = 3;

    void Start()
    {
    }

    void Update()
    {
        TextoftheScore.text = "Score:" + CurrentScore;
    }
}
