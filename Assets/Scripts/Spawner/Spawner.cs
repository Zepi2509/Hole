using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables
    // Serialize Fields
    [SerializeField] private GameObject blockWhite;
    [SerializeField] private GameObject blockRed;
    [SerializeField] private GameObject blockGold;

    // Components
    private static GameObject BlockWhite;
    private static GameObject BlockRed;
    private static GameObject BlockGold;

    // Vector 3
    private static Vector3 randomPosition;
    #endregion


    private void Awake()
    {
        BlockWhite = blockWhite;
        BlockRed = blockRed;
        BlockGold = blockGold;
    }

    public static void SpawnNewBlock()
    {
        for (int i = 0; i < UnityEngine.Random.Range(0, 4); i++)
        {
            int randomNum = UnityEngine.Random.Range(0, 11);

            if (randomNum <= 7)
            {
                Instantiate(BlockWhite, new Vector3(UnityEngine.Random.Range(-9, 9), 10, UnityEngine.Random.Range(-9, 9)), Quaternion.identity);
            }else if(randomNum == 8)
            {
                Instantiate(BlockRed, new Vector3(UnityEngine.Random.Range(-9, 9), 10, UnityEngine.Random.Range(-9, 9)), Quaternion.identity);
            }
            else if (randomNum >= 9)
            {
                Instantiate(BlockGold, new Vector3(UnityEngine.Random.Range(-9, 9), 10, UnityEngine.Random.Range(-9, 9)), Quaternion.identity);
            }
        }
    }
}
