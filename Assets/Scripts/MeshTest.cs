using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshTest : MonoBehaviour
{
	[SerializeField] private float shapeCreationTime = .02f;
	[SerializeField] private int xLength;
	[SerializeField] private int zLength;

	private Mesh mesh;

	private Vector3[] vertices;
	private int[] triangles;

	private void Awake()
	{
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
	}

	private void Start()
	{
		CreateShape();
	}

	private void Update()
	{
		UpdateMesh();
	}

	private void CreateShape()
	{
		vertices = new Vector3[(xLength + 1) * (zLength + 1)];

		for (int i = 0, z = 0; z <= zLength; z++)
		{
			for (int x = 0; x <= xLength; x++)
			{
				vertices[i] = new Vector3(x, 0, z);
				i++;
			}
		}

		triangles = new int[xLength * zLength * 6];

		int vert = 0;
		int tris = 0;
		for (int z = 0; z < zLength; z++)
		{
			for (int x = 0; x < xLength; x++)
			{
				triangles[tris + 0] = vert + 0;
				triangles[tris + 1] = vert + xLength + 1;
				triangles[tris + 2] = vert + 1;
				triangles[tris + 3] = vert + 1;
				triangles[tris + 4] = vert + xLength + 1;
				triangles[tris + 5] = vert + xLength + 2;
				vert++;
				tris += 6;
			}
			vert++;
		}
	}

	private void UpdateMesh()
	{
		mesh.Clear();

		mesh.vertices = vertices;
		mesh.triangles = triangles;

		mesh.RecalculateNormals();
	}

	private void OnDrawGizmos()
	{
		if (vertices == null)
		{
			return;
		}
		for (int i = 0; i < vertices.Length; i++)
		{
			Gizmos.DrawSphere(vertices[i], .1f);
		}
	}
}
