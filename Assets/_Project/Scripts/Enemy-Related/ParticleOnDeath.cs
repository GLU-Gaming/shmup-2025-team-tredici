using UnityEngine;

public class ParticleOnDeath : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject , 1f);
    }

    void Update()
    {

    }
}
