using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SetDirty : MonoBehaviour {

    [MenuItem("Assets/SetSceneDirty", false, -1)]
    static void SetSceneDirty()
    {
        //设置场景dirty
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        //设置Prefab dirty
        EditorUtility.SetDirty(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Cube.prefab"));
    }
}
