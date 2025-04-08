using System.Collections;
using UnityEngine;

public class Shake : MonoBehaviour
{
    //CREDITS :https://www.youtube.com/watch?v=BQGTdRhGmE4

    public float duration = 1f;
    public AnimationCurve curve;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float esapsedTime = 0f;
        while (esapsedTime < duration)
        {
            esapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(esapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;
    }
    public void StartShake()
    {
        StartCoroutine(Shaking());
    }

}