using System.IO;
using UnityEngine;
using UnityEditor;

public class OpenFIleSelector : EditorWindow
{
    public string path;

    [MenuItem("")]
    public void Apply()
    {
        Texture2D texture = Selection.activeObject as Texture2D;

        if (texture == null)
        {
            EditorUtility.DisplayDialog("Select Excel", "You must select an excel firast!", "OK");
            return;
        }

        path = EditorUtility.OpenFilePanel("Excel with coordinates", "", "csv");

    }

        
}
