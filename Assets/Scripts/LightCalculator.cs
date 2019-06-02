using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCalculator : MonoBehaviour
{
    public Mesh mesh;
    public Vector3[] vertices;
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
    }

    void Update()
    {
        for (var i = 0; i < vertices.Length; i++)
        {
            //vertices[i] += Vector3.up * Time.deltaTime;
        }

        // assign the local vertices array into the vertices array of the Mesh.
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}
