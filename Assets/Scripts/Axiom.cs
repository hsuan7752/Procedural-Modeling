using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Axiom : Components
{
    public List<GameObject> gameObjects = new List<GameObject>();
    public static Axiom CreateComponent(string n, Vector3 pos, Vector3 s)
    {
        name = n;
        position = pos;
        scale = s;
        Axiom obj = new GameObject(n).AddComponent<Axiom>();
        return obj;
    }

    private void Awake()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        name = plane.name;
        plane.transform.parent = transform;
        plane.transform.localScale = scale;

        gameObjects.Add(plane);
    }
}
