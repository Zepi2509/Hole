using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Unity.Mathematics;
using UnityEngine;

public class BlockWhite : MonoBehaviour
{
    // Serialize Fields
    [SerializeField] private int points = 1;
    [SerializeField] private int coins = 1;
    [SerializeField] private float energyPoints = 1;
    [SerializeField] private GameObject cubeInPrefab;
    [SerializeField] private Material blockGold;

    // Components
    private Renderer rendererComponent;
    private Material normalMaterial;


    // Is called when script instancs is loaded
    private void Awake()
    {
        rendererComponent = cubeInPrefab.GetComponent<Renderer>();
        normalMaterial = rendererComponent.material;
    }

    // Is called every frame
    private void Update()
    {
        if (transform.position.y <= Game.groundBorder)
        {
            if (Game.isAbilityActivated)
            {
                Game.AddCoins(coins);
            }
            else
            {
                Game.AddPoints(points);
                Game.AddEnergy(energyPoints);
            }

            Spawner.SpawnNewBlock();
            Destroy(gameObject);
        }

        if (Game.isAbilityActivated)
        {
            rendererComponent.material = blockGold;
        }
        else
        {
            rendererComponent.material = normalMaterial;
        }
    }
}
