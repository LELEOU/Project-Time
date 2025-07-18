using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, player.position, 0.1f);
    }
}
