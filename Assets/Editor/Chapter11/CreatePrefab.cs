using UnityEngine;
using UnityEditor;

public class CreatePrefab
{
    [MenuItem("Assets/My Tools/Create Prefab", false, 3)]
    static void CreatePrefabs()
    {
        if (Selection.activeTransform)
        {
            string path = "Assets/Prefab.prefab";
            //如果文件已经存在，删除它
            if (AssetDatabase.LoadAssetAtPath<GameObject>(path))
            {
                AssetDatabase.DeleteAsset(path);
            }

            //创建新的Prefab
            PrefabUtility.CreatePrefab("Assets/Prefab.prefab", Selection.activeGameObject,
                ReplacePrefabOptions.ConnectToPrefab);

            //刷新Project视图目录
            AssetDatabase.Refresh();
        }
    }
}
