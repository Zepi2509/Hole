using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{ 
    // To load MainMenu
    public void LoadMainMenu()
    {
        Game.isGamePaused = true;
        SceneManager.LoadScene("MainMenu");
    }

    // To load SettingsMenu
    public void LoadSettingsMenu()
    {
        Game.isGamePaused = true;
        SceneManager.LoadScene("SettingsMenu");
    }

    // To load Game
    public void LoadGame()
    {
        Game.isGamePaused = false;
        SceneManager.LoadScene("Game");
    }

    public void ReloadActiveScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(thisScene);
        SceneManager.LoadScene(thisScene.name);
    }

    // To quit the game
    public void Quit()
    {
        Application.Quit();
    }
}
