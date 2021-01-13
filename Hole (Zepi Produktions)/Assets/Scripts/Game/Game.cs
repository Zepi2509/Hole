using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // publics
    public static bool isGameover = false;
    
    // Serialize Fields
    [SerializeField] public static float groundBorder = -10;

    private void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (isGameover)
        {
            SceneManagement.LoadSceneGameOver();
        }
    }
}