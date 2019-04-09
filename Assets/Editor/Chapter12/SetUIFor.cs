using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetUIFor :AssetPostprocessor {
    [MenuItem("Assets/SetTextureFormat", false, -1)]
    static void SetTextureFormat()
    {
        //确保在Project视图中选择一个文件
        if (Selection.assetGUIDs.Length > 0)
        {
            AssetImporter import = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(Selection.activeObject));
            //确保选择的是一个贴图文件
            if (import is TextureImporter)
            {
                (import as TextureImporter).SetPlatformTextureSettings("Standalone", 2048, TextureImporterFormat.RGBA32, true);
                //保存并且重新导入
                import.SaveAndReimport();
            }
        }
    }

}
