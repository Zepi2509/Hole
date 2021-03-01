using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGold : MonoBehaviour
{
    // Is called every frame
    private void Update()
    {
        if (transform.position.y <= Game.groundBorder)
        {
            Game.AddCoins(1);
            Spawner.SpawnNewBlock();
            Destroy(gameObject);
        }
    }
}
