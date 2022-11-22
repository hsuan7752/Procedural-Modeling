using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FacadesEditor : MonoBehaviour
{
    public static FacadesEditor Instance;

    static string[] grammars;

    #region FacadeSize
    public float height = 3;
    public float width = 3;
    #endregion

    #region Facade Split
    public int splitX = 1;
    public int splitY = 1;
    #endregion

    List<GameObject> gameObjects = new List<GameObject>();

    public void Init()
    {
        CreateBuilding();
    }

    public void CreateBuilding()
    {
        if (transform.childCount != 0)
        {
            foreach (Transform child in transform)
                DestroyImmediate(child.gameObject);
        }

        Wall.CreateComponent("Facade", width, height, splitX, splitY).transform.SetParent(transform, true);
    }
}
