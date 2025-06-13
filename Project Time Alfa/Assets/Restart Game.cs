using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartGame: MonoBehaviour
{
    public void RestarLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
