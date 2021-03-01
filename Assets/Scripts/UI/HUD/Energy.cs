using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Energy : MonoBehaviour
{
    // Components
    private TMP_Text tmpComponent;



    private void Awake()
    {
        tmpComponent = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        tmpComponent.text = $@"Energie: {Game.energy}%";
    }
}
