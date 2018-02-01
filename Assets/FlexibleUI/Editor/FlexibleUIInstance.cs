using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FlexibleUIInstance : Editor
{
    [MenuItem("GameObject/UI/Button (Icon)")]
    public static void AddIconButton()
    {
        Create("IconButton");
    }

    [MenuItem("GameObject/UI/Button (Text)")]
    public static void AddTextButton()
    {
        Create("TextButton");
    }

    static GameObject clickedObject;

    private static GameObject Create(string objectName)
    {
        GameObject instance = Instantiate(Resources.Load<GameObject>(objectName));
        instance.name = objectName;
        clickedObject = UnityEditor.Selection.activeObject as GameObject;
        if(clickedObject != null)
        {
            instance.transform.SetParent(clickedObject.transform, false);
        }
        return instance;
    }
	
}
