using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Renombrador))]
public class RenombradorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Renombrador myScript = (Renombrador)target;
        if (GUILayout.Button("Renombra"))
        {
            myScript.RenombrarHijos();
        }
    }
}