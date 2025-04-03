using UnityEngine;

public class ParticleExclamation : MonoBehaviour
{
    [SerializeField] GameObject particle;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(particle,transform.position ,transform.rotation);
    }
}
