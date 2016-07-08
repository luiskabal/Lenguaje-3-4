using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SeparadorHijos))]
public class SeparadorHijosEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SeparadorHijos myScript = (SeparadorHijos)target;
        if (GUILayout.Button("Build Object"))
        {
            myScript.Separate();
        }

        if (GUILayout.Button("Zero"))
        {
            myScript.EverybodyToZero();
        }
    }
}