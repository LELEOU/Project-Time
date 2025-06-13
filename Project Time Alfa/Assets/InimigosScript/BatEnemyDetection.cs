using UnityEngine;

public class BatEnemyDetection : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5f;
    private BatAI movement;

    void Start()
    {
        movement = GetComponent<BatAI>();
    }

    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= detectionRange)
        {
            movement.ActivateBat();
        }
    }
}
