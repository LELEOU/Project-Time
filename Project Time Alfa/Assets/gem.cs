using UnityEngine;

public class GemPickup : MonoBehaviour
{
    public GameObject gameOverui;
    public string messanger ="Congratulation";
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameOverui.SetActive(true);

            Time.timeScale =0f;
        }
    }
}
