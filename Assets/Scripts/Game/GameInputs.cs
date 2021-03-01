using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputs : MonoBehaviour
{
    #region Variables
    // Publics
    public static InputMaster inputMaster;
    #endregion

    // Is called when the script is loaded
    private void Awake()
    {
        inputMaster = new InputMaster();
    }
}
