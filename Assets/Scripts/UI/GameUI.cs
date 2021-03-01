using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    // Serialize Fields
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject abilityText;



    private void Awake()
    {
        Game.isGameOver = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (InputSystem.GetDevice<Keyboard>().escapeKey.wasPressedThisFrame)
            {
                if (Game.isGamePaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }

            if (!Game.isGameOver)
            {
                gameOverUI.SetActive(false);
                if (!Game.isGamePaused)
                {
                    HideCursor();
                    Time.timeScale = 1;
                    Game.isGamePaused = false;
                }
            }
            else
            {
                ShowCursor();
                gameOverUI.SetActive(true);
                Time.timeScale = 0;
                Game.isGamePaused = true;
            }

            if (Game.energy == 100)
            {
                abilityText.SetActive(true);
            }
            else
            {
                abilityText.SetActive(false);
            }
        }
        else
        {
            ShowCursor();
        }
    }

    public void PauseGame()
    {
        ShowCursor();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        Game.isGamePaused = true;
    }

    public void ResumeGame()
    {
        HideCursor();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        Game.isGamePaused = false;
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
    }
}
