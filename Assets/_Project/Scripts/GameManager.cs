using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextoftheScore;
    public int CurrentScore;
    public int CurrentLifes = 3;
    [SerializeField] private GameObject[] Hearts;
    [SerializeField] private GameObject Bluescreen;
    private Shake ShakeScript;
    private bool BossBattleActive = false;
    private bool BluescreenActivated = false;

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
        if (CurrentScore >= 50 && BossBattleActive == false && BluescreenActivated == false && Bluescreen.activeSelf == false)
        {
            DestroyEnemies();
            Bluescreen.SetActive(true);
        }
        else if (CurrentScore >= 50 && BluescreenActivated == true)
        {
            Bluescreen.SetActive(false);
            BluescreenActivated = false;
            BossBattleActive = true;
            ShakeScript.StartShake();
        }

        if (Bluescreen.activeSelf == true)
        {
            int i = 0;
            i++;
            if (i >= 10)
            {
                BluescreenActivated = true;
            }
              
            
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
