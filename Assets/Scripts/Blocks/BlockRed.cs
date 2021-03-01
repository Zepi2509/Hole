using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRed : MonoBehaviour
{
    [SerializeField] private float removeLives = 1;

    // Is called every frame
    private void Update()
    {
        if (transform.position.y <= Game.groundBorder)
        {
            Destroy(gameObject);
            Spawner.SpawnNewBlock();
            Game.RemoveLive(removeLives);
        }
    }
}
