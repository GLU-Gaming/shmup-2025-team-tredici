using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextoftheScore;
    public int CurrentScore;
    public int CurrentLifes = 3;
    // Alot of gameobjects to turn off/on
    [SerializeField] private GameObject[] Hearts;
    [SerializeField] private GameObject Bluescreen;
    [SerializeField] private GameObject Smiley;
    [SerializeField] private GameObject Popups;
    [SerializeField] private GameObject BossbattleProgressbar;
    [SerializeField] private GameObject Hills;
    [SerializeField] private GameObject NormalBGMusic;
    [SerializeField] private GameObject BossBGMusic;
    [SerializeField] private GameObject SafeSpotText;
    private Shake ShakeScript;
    private bool BossBattleActive = false;

    void Start()
    {
        ShakeScript = FindFirstObjectByType<Shake>();
    }

    void Update()
    {
        TextoftheScore.text = "Score: " + CurrentScore;
        //if you die you go to death scene
        if (CurrentLifes <= 0)
        {
            PlayerPrefs.SetInt("CurrentScore", CurrentScore);
            PlayerPrefs.Save();
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
            ShakeScript.StartShake();
            Bluescreen.SetActive(true);
            NormalBGMusic.SetActive(false);
            BossBGMusic.SetActive(true);
            BossBattleActive = true;
            BossbattleProgressbar.SetActive(true);
            Smiley.SetActive(true);
            Popups.SetActive(false);
            Hills.SetActive(false);
        }
    }

    private void DestroyEnemies()
    {
        //Destroys every enemy and bullet when the boss battle starts
        GameObject[] CurrentEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] CurrentBullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject Enemy in CurrentEnemies) { Destroy(Enemy); }
        foreach (GameObject Bullet in CurrentBullets) { Destroy(Bullet); }
    }
}
