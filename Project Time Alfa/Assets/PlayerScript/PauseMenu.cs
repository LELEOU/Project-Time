using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    // Lista dos scripts que devem ser desabilitados quando o jogo for pausado (por exemplo, PlayerController, etc.)
    public MonoBehaviour[] disableOnPause;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        // Desativa todos os scripts que controlam o input do jogador
        foreach (MonoBehaviour script in disableOnPause)
        {
            if (script != null)
                script.enabled = false;
        }
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        // Reativa os scripts
        foreach (MonoBehaviour script in disableOnPause)
        {
            if (script != null)
                script.enabled = true;
        }
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
