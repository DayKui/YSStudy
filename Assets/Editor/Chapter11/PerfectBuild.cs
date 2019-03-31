using UnityEngine;
using System.IO;
using UnityEngine.Events;
using UnityEditor;
using System.Collections.Generic;


public class PerfectBuild
{
    [MenuItem("Tools/BuildAssetbundle1")]
    static void BuildAssetbundle()
    {
        string outPath = Path.Combine(Application.dataPath, "PerABAssets");

        //如果目录已经存在删除它
        if (Directory.Exists(outPath))
        {
            Directory.Delete(outPath, true);
        }
        Directory.CreateDirectory(outPath);

        List<AssetBundleBuild> builds = new List<AssetBundleBuild>();
        //设置bundle名，和多少资源打在同一个Bundle内
        builds.Add(new AssetBundleBuild() { assetBundleName = "Cube1.unity3d", assetNames = new string[] { "Assets/PerAssetBuildAssets/Cube3.prefab", "Assets/PerAssetBuildAssets/Cube4.prefab" } });
        builds.Add(new AssetBundleBuild() { assetBundleName = "New Material1.unity3d", assetNames = new string[] { "Assets/PerAssetBuildAssets/NormalMat1.mat" } });

        //构建Assetbundle
        BuildPipeline.BuildAssetBundles(outPath, builds.ToArray(), BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
        //刷新
        AssetDatabase.Refresh();
    }
}
