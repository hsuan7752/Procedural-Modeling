using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Wall : Components
{
    public List<GameObject> gameObjects = new List<GameObject>();

    static int splitX;
    static int splitY;

    public static Wall CreateComponent(string n, float w, float h, int x, int y)
    {
        name = n;
        splitX = x;
        splitY = y;

        Debug.Log("SplitX: " + splitX);
        width = w;
        height = h;        

        Wall obj = new GameObject(n).AddComponent<Wall>();
        return obj;
    }

    private void Start()
    {
        int block = splitX * splitY;

        float childheight = height / splitY;
        float childwidth = width / splitX;

        Debug.Log(childwidth);

        for (int i = 0; i < block; ++i)
        {
            GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Quad);
            buildMesh(wall, childheight, childwidth, new Vector3(i % splitX * childwidth, i / splitX * childheight, 0));
            //buildMesh(wall, height, width, new Vector3(0, 0, 0));
            wall.transform.SetParent(transform, true);
            gameObjects.Add(wall);
        }
    }

    public Mesh buildMesh(GameObject w, float childheight, float childwidth, Vector3 pos)
    {
        Vector3[] newVertices;
        Vector2[] newUV;
        int[] newTriangles;

        Mesh mesh = new Mesh();
        DestroyImmediate(w.GetComponent<MeshCollider>());
        w.GetComponent<MeshFilter>().mesh = mesh;

        newVertices = SetVertices(childheight, childwidth, pos);
        newUV = SetUV(childheight, childwidth);
        newTriangles = SetTriangles();

        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;
        return mesh;
    }

    private Vector3[] SetVertices(float childheight, float childwidth, Vector3 pos)
    {
        Vector3[] vertices = new Vector3[4];

        vertices[0] = pos;
        vertices[1] = new Vector3(pos.x + childwidth, pos.y, pos.z);
        Debug.Log(childwidth);
        vertices[2] = new Vector3(pos.x, pos.y + childheight, pos.z);
        vertices[3] = new Vector3(pos.x + childwidth, pos.y + childheight, pos.z);

        return vertices;
    }
    private Vector2[] SetUV(float childheight, float childwidth)
    {
        Vector2[] uvs = new Vector2[4];

        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(1, 0);
        uvs[2] = new Vector2(0, 1);
        uvs[3] = new Vector2(1, 1);

        return uvs;
    }

    private int[] SetTriangles()
    {
        int[] triangles = new int[6] { 0, 2, 1, 2, 3, 1 };

        return triangles;
    }
}
