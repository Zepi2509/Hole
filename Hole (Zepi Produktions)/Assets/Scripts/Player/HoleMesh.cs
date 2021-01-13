using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class HoleMesh : MonoBehaviour
{
    // Serialize Fields
    [Header("Hole mesh")]
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshCollider meshCollider;
    [Space]
    [SerializeField] private Transform holeCenter;

    [Header("Hole")]
    [SerializeField] [Range(0, 5)] private float radius = 1.5f;

    //Mesh
    private Mesh mesh;
    private List<int> holeVertices;
    private List<Vector3> offsets;
    private int holeVerticesCount;



    // Is called when the script instance is loaded
    private void Awake()
    {
        holeVertices = new List<int>();
        offsets = new List<Vector3>();
        mesh = meshFilter.mesh;

        // Find hole vertices on the mesh
        FindHoleVertices();
    }

    // Is called every physik frame
    private void FixedUpdate()
    {
        UpdateHoleVerticesPosition();
    }

    // Is called if the hole is moving
    private void UpdateHoleVerticesPosition()
    {
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < holeVerticesCount; i++)
        {
            vertices[holeVertices[i]] = holeCenter.position + offsets[i];
        }

        // Update mesh
        mesh.vertices = vertices;
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }

    private void FindHoleVertices()
    {
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            //Calculate distance between holeCenter & each Vertex
            float distance = Vector3.Distance(holeCenter.position, mesh.vertices[i]);

            if (distance < radius)
            {
                //this vertex belongs to the Hole
                holeVertices.Add(i);
                //offset: how far the Vertex from the HoleCenter
                offsets.Add(mesh.vertices[i] - holeCenter.position);
            }
        }

        // Nur zum Testen
        //foreach (Vector3 tempVector3 in offsets)
        //{
        //    Debug.Log(tempVector3);
        //}

        //save hole vertices count
        holeVerticesCount = holeVertices.Count;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(holeCenter.position, radius);
    }
}
