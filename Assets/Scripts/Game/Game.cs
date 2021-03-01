using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.InputSystem;

public class Game : MonoBehaviour
{
    #region Variables
    // Publics
    public static bool isGamePaused = true;
    public static bool isGameOver = true;
    public static bool isAbilityActivated = false;
    public static float groundBorder = -10;
    public static float points;
    public static int coins;
    public static float energy;
    public static float lives;

    // Serialize Fields
    [SerializeField] private int setPoints;
    [SerializeField] private int setCoins;
    [SerializeField] [Range(0, 100)] private float setEnergy = 0;
    [SerializeField] private int setLives;
    [SerializeField] private float abilityDelay;
    #endregion

    // Is called when script instancs is loaded
    private void Awake()
    {
        // Set points
        points = setPoints;
        // Set coins
        coins = setCoins;
        // Set energy
        energy = setEnergy;
        // Set lives
        lives = setLives;
    }

    // Is called every frame
    private void Update()
    {
        GameOver();

        if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
        {
            Ability();
        }
    }

    // Quits the game
    private void GameOver()
    {
        if(lives == 0)
        {
            isGameOver = true;
        }
    }

    // Add point
    public static void AddPoints(int x)
    {
        points += x;
    }

    // Add coin
    public static void AddCoins(int x)
    {
        coins += x;
    }

    // Add energy
    public static void AddEnergy(float x)
    {
        if (energy < 100)
        {
            energy += x;
        }
    }

    // Remove live
    public static void RemoveLive(float x)
    {
        lives -= x;
    }

    // Is called when the button for the ability is pressed
    private void Ability()
    {
            energy = 0;
            isAbilityActivated = true;
            Invoke("deactivateAbility", abilityDelay);
    }

    // Deactivates the Ability (Is important for the delay)
    private void deactivateAbility()
    {
        isAbilityActivated = false;
    }

    // Is called when this GameObject is enabled
    private void OnEnable()
    {
        GameInputs.inputMaster.Enable();
    }

    // Is called when this GameObjekt is disabled
    private void OnDisable()
    {
        GameInputs.inputMaster.Disable();
    }
}