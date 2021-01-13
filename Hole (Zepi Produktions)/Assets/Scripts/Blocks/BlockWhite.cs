using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWhite : MonoBehaviour
{
    // Is called every frame
    private void Update()
    {
        if (transform.position.y <= Game.groundBorder)
        {
            Destroy(gameObject);
        }
    }
}
