using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextoftheScore;
    public int CurrentScore;
    public int CurrentLifes = 3;
    [SerializeField] private GameObject[] Hearts;

    void Start()
    {
    }

    void Update()
    {
        TextoftheScore.text = "Score: " + CurrentScore;
        if (CurrentLifes <= 0)
        {
            //if you die you go to death scene
            SceneManager.LoadScene(2);

        }

        // Sets the hearts depending on the current lives
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
