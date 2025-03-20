using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextoftheScore;
    [SerializeField] TextMeshProUGUI TextofLifes; //TEMP - Will become objects
    public int CurrentScore;
    public int CurrentLifes = 3;

    void Start()
    {
    }

    void Update()
    {
        TextoftheScore.text = "Score: " + CurrentScore;
        TextofLifes.text = "Lifes: " + CurrentLifes;
    }
}
