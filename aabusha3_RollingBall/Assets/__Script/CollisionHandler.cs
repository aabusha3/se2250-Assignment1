using UnityEngine;


public class CollisionHandler : MonoBehaviour
{
    private Score score;
    void Start()
    {
        score = FindObjectOfType<Score>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "CubePickUp")
        {
            Destroy(collision.gameObject);
            score.Scored(1);
        }

        if (collision.collider.tag == "CylinderPickUp")
        {
            Destroy(collision.gameObject);
            score.Scored(5);
        }

        if (collision.collider.tag == "CapsulePickUp")
        {
            Destroy(collision.gameObject);
            score.Scored(10);
        }
    }
}
