using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                ResumeGame();
            }
            else
            {
                TogglePauseGame();
            }
        }
    }


    public void TogglePauseGame()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausa el tiempo en el juego
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f; // Restaura el tiempo en el juego a su velocidad normal
            pausePanel.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Restaura el tiempo en el juego a su velocidad normal
        pausePanel.SetActive(false);
    }
}
