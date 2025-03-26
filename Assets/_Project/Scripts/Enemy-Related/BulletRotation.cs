using UnityEngine;

public class BulletRotation : MonoBehaviour
{
    [SerializeField] private string WhichBullet;

    void Update()
    {
        if (WhichBullet == "Eye")
        {
            transform.Rotate(0, 0, 1f);
        }

        if (WhichBullet == "Web")
        {
            transform.Rotate(1f, 0, 0);
        }

        if (WhichBullet == "Bone")
        {
            transform.Rotate(0, 1f, 0);
        }
    }
}
