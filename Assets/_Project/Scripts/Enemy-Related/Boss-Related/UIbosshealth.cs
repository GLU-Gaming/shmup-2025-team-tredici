using TMPro;
using UnityEngine;

public class UIbosshealth : MonoBehaviour
{
    [SerializeField] private TMP_Text HealthBar;
    private BossScript BossScript;

    void Start()
    {
        BossScript = FindFirstObjectByType<BossScript>();
    }

    void Update()
    {
        HealthBar.text = BossScript.CurrentHealth.ToString() + "% incomplete";
    }
}
