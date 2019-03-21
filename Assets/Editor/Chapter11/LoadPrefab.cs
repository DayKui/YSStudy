using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LoadPrefab
{
    [MenuItem("Assets/MyTools/LoadPrefab",false ,2)]
    static void LoadPrefabs()
    {
        if (Selection.activeTransform)
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Cube.prefab");
            GameObject go = GameObject.Instantiate<GameObject>(prefab);
           // GameObject go = PrefabUtility.InstantiatePrefab(prefab)as GameObject;
            go.transform.SetParent(Selection.activeTransform,false);
        }
    }
	
}
