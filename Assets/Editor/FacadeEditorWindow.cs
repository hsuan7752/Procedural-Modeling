using UnityEditor;
using UnityEngine;

public class FacadeEditorWindow : EditorWindow
{
    #region FacadeSize
    float height = 3;
    float width = 3;
    #endregion

    #region FacadeSplit
    int splitX = 1;
    int splitY = 1;
    #endregion

    public static FacadeEditorWindow Instance;
    private FacadesEditor facades;

    [MenuItem("Facade/Facade Editor")]
    static void Init()
    {
        Instance = (FacadeEditorWindow)GetWindow(typeof(FacadeEditorWindow));
        Instance.Show();

        GameObject tmp = GameObject.Find("Facades");

        if (tmp == null)
        {
            FacadesEditor.Instance = new GameObject("Facades").AddComponent<FacadesEditor>();
            FacadesEditor.Instance.Init();
        }
        else
        {
            FacadesEditor.Instance = tmp.GetComponent<FacadesEditor>();
            FacadesEditor.Instance.Init();
        }

        Instance.facades = FacadesEditor.Instance;
    }

    void OnGUI()
    {
        if (facades == null)
            return;

        #region FacadeSize
        EditorGUILayout.LabelField("Facade Size");
        facades.height = EditorGUILayout.Slider("Height", height, 3, 10);
        if (facades.height != height)
        {
            FacadesEditor.Instance.CreateBuilding();
            height = facades.height;
        }

        facades.width = EditorGUILayout.Slider("Width" , width, 3, 10);
        if (facades.width != width)
        {
            FacadesEditor.Instance.CreateBuilding();
            width = facades.width;
        }
        #endregion

        #region FacadeSplit
        EditorGUILayout.LabelField("Facade Split");
        facades.splitX = EditorGUILayout.IntSlider("X", splitX, 1, 10);
        if (facades.splitX != splitX)
        {
            FacadesEditor.Instance.CreateBuilding();
            splitX = facades.splitX;
        }

        facades.splitY = EditorGUILayout.IntSlider("Y", splitY, 1, 10);
        if (facades.splitY != splitY)
        {
            FacadesEditor.Instance.CreateBuilding();
            splitY = facades.splitY;
        }
        #endregion
    }

    private void Update()
    {
        Instance = this;
        facades = FacadesEditor.Instance;

        if (facades == null)
            Close();
    }
}
