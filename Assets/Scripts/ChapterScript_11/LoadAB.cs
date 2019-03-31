using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAB : MonoBehaviour {

   
    void Start()
    {
        string path = Application.dataPath + "/PerABAssets";
        AssetBundle assetbundle = AssetBundle.LoadFromFile(Path.Combine(path, "PerABAssets"));
        AssetBundleManifest manifest = assetbundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

        //加载Assetbundle前需要加载依赖的Bundle
        foreach (var item in manifest.GetAllDependencies("cube1.unity3d"))
        {
            AssetBundle.LoadFromFile(Path.Combine(path, item));
        }
        //读取Bundle
        assetbundle = AssetBundle.LoadFromFile(Path.Combine(path, "cube1.unity3d"));
        //从Bundle中读取资源
        GameObject prefab = assetbundle.LoadAsset<GameObject>("Cube3");
        //实例化资源
        GameObject.Instantiate<GameObject>(prefab);
    }
}
