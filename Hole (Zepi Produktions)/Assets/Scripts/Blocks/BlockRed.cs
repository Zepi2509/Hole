using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRed : MonoBehaviour
{
    // Is called every frame
    private void Update()
    {
        if (transform.position.y <= Game.groundBorder)
        {
            Destroy(gameObject);
            Game.isGameover = true;
        }
    }
}
