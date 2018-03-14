using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(LevelGenerator))]
public class LevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LevelGenerator level = target as LevelGenerator;

        // True if the value is being updated in the inspector
        
        if (DrawDefaultInspector ())
        {
            level.GenerateLevel();
        }
        

        if (GUILayout.Button("Generate Level"))
        {
            level.GenerateLevel();
        }
    }
}
