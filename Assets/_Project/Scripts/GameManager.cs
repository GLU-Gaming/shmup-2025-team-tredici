using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextoftheScore;
    [SerializeField] TextMeshProUGUI TextofLifes; //TEMP - Will become objects
    public int CurrentScore;
    public int CurrentLifes = 3;
    [SerializeField] private GameObject[] Hearts;

    void Start()
    {
    }

    void Update()
    {
        TextoftheScore.text = "Score: " + CurrentScore;
        TextofLifes.text = "Lifes: " + CurrentLifes;
        if (CurrentLifes <= 0)
        {
            SceneManager.LoadScene(2);

        }

        if (CurrentLifes == 2)
        {
            Hearts[2].SetActive(false);
            Hearts[5].SetActive(true);
        }
        else if (CurrentLifes == 1)
        {
            Hearts[1].SetActive(false);
            Hearts[4].SetActive(true);
        }
    }
}
