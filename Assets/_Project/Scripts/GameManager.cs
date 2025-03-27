using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextoftheScore;
    public int CurrentScore;
    public static int FinalScore;
    public int CurrentLifes = 3;
    [SerializeField] private GameObject[] Hearts;
    private Shake ShakeScript;
    private bool BossBattleActive = false;

    void Start()
    {
        ShakeScript = FindFirstObjectByType<Shake>();
        FinalScore = 0;
    }

    void Update()
    {
        TextoftheScore.text = "Score: " + CurrentScore;
        if (CurrentLifes <= 0)
        {
            //if you die you go to death scene
            CurrentScore = FinalScore;
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

        //Boss battle start
        if (CurrentScore >= 50 && BossBattleActive == false)
        {
            DestroyEnemies();
            BossBattleActive=true;
        }
    }

    private void DestroyEnemies()
    {
        GameObject[] CurrentEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] CurrentBullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject Enemy in CurrentEnemies)
            Destroy(Enemy);
        foreach (GameObject Bullet in CurrentBullets)
            Destroy(Bullet);

       ShakeScript.StartShake();
    }
}
