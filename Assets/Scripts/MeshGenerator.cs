using System;
using System.Collections;
using UnityEngine;
using static GenerationValues;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshFilter))]
public class SurfaceGenerator : MonoBehaviour
{

    private Vector3[] vertices;
    private int[] triangles;
    
    private Mesh mesh;
    
    
    private int xSize = size, zSize = size;
    
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        GenerateMesh();
        UpdateMesh();
    }
    
    void GenerateMesh()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float yPos = yPosition;
                float localScale = scale; //Escala de la superficie
                float xPos = (x / (float)xSize) * localScale; //Esta multiplicacion se hace para aplicar la escala
                float zPos = (z / (float)zSize) * localScale;

                if (perlinNoise == true)
                {
                    yPos = Mathf.PerlinNoise(x * .3f, z * .3f)* Random.Range(0f, yPosition);
                }
                if (sincon == true)
                {
                    yPos = Mathf.Sin(xPos) * Mathf.Cos(zPos) * Random.Range(0f, yPosition);
                }
                vertices[i] = new Vector3(xPos, yPos, zPos);
                i++;
            }
        }
        
        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;

            }
            vert++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}