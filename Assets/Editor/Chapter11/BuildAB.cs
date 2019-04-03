using UnityEngine;
using System.IO;
using UnityEngine.Events;
using UnityEditor;
using System.Collections.Generic;


public class BuildAB
{
    [MenuItem("Tools/BuildAssetbundle2")]
    static void BuildAssetbundle()
    {
        string outPath = Path.Combine(Application.dataPath, "StreamingAssets");

        //如果目录已经存在删除它
        if (Directory.Exists(outPath))
        {
            Directory.Delete(outPath, true);
        }
        Directory.CreateDirectory(outPath);

        List<AssetBundleBuild> builds = new List<AssetBundleBuild>();
        //设置bundle名，和多少资源打在同一个Bundle内
        builds.Add(new AssetBundleBuild()
        {
            assetBundleName = "Cube.unity3d",
            assetNames = new string[]{"Assets/Resources/Cube.prefab",
                "Assets/Resources/Cube1.prefab"}
        });

        //构建Assetbundle
        BuildPipeline.BuildAssetBundles(outPath, builds.ToArray(), BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.DeterministicAssetBundle, BuildTarget.StandaloneWindows64);

        //生成描述文件
        BundleList bundleList = ScriptableObject.CreateInstance<BundleList>();
        foreach (var item in builds)
        {
            foreach (var res in item.assetNames)
            {
                bundleList.bundleDatas.Add(new BundleList.BundleData() { resPath = res, bundlePath = item.assetBundleName });
            }
        }
        AssetDatabase.CreateAsset(bundleList, "Assets/Resources/bundleList.asset");

        //刷新
        AssetDatabase.Refresh();
    }
}
