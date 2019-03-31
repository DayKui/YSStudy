using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class NorlmalBuild : MonoBehaviour {

    [MenuItem("Tools/BuildAssetbundle")]
    static void BuildAssetbundle()
    {
        string outPath = Path.Combine(Application.dataPath, "StreamingAssets");

        //如果目录已经存在删除它
        if (Directory.Exists(outPath))
        {
            Directory.Delete(outPath, true);
        }
        Directory.CreateDirectory(outPath);

        //构建Assetbundle
        BuildPipeline.BuildAssetBundles(outPath, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows);
        //刷新
        AssetDatabase.Refresh();
    }
}
