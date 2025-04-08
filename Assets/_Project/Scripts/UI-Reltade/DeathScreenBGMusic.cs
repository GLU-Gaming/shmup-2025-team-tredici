using UnityEngine;
using UnityEngine.Audio;

public class DeathScreenBGMusic : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public GameObject bgmusic;
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (m_AudioSource.isPlaying)
        {

        }
        else
        {
            gameObject.SetActive(false);
            bgmusic.SetActive(true);
        }
    }
}
