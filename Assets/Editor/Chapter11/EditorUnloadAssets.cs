using UnityEngine;
using UnityEditor;

public class EditorUnloadAssets
{
    [MenuItem("Assets/My Tools/UnloadUnusedAssetsImmediate", false, 3)]
    static void UnloadUnusedAssetsImmediate()
    {
        EditorUtility.UnloadUnusedAssetsImmediate();
    }
}
