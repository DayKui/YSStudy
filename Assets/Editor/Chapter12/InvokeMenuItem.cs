using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class InvokeMenuItem : AssetPostprocessor {

    [MenuItem("Assets/AutoMenuItem",false,-1)]
	static void AutoMenuItem()
    {
        Selection.activeObject = AssetDatabase.LoadAssetAtPath("Assets/Resources/Plane.prefab", typeof(Object));
        //执行Command + D 复制
        EditorApplication.ExecuteMenuItem("Edit/Duplicate");
        //自动选择Prefab
        Selection.activeObject = AssetDatabase.LoadAssetAtPath("Assets/Resources/Cube.prefab", typeof(Object));
        //执行Command + D 复制
        EditorApplication.ExecuteMenuItem("Edit/Duplicate");
    }
}
