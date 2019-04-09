using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetsPoseEvent : AssetPostprocessor {

    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string str in importedAssets)
        {
            Debug.LogFormat("新导入的资源: {0}", str);
        }

        foreach (string str in deletedAssets)
        {
            Debug.LogFormat("删除的资源: {0}", str);
        }

        for (int i = 0; i < movedAssets.Length; i++)
        {
            Debug.LogFormat("移动资源位置: from: {0} to :{1}", movedFromAssetPaths[i], movedAssets[i]);
        }
    }
}
