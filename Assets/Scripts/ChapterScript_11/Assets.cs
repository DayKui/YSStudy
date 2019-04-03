using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Assets
{
    static Dictionary<string, string> m_ResAbDic = new Dictionary<string, string>();
    static Dictionary<string, AssetBundle> m_BundleCache = new Dictionary<string, AssetBundle>();
    static Assets()
    {
        //读取依赖关系
        BundleList list = Resources.Load<BundleList>("bundleList");
        foreach (var bundleData in list.bundleDatas)
        {
            m_ResAbDic[bundleData.resPath] = bundleData.bundlePath;
        }
    }

    static public T LoadAsset<T>(string path) where T : Object
    {
        //从Assetbundle中加载资源，最好提供后缀名，不然无法区分同名文件
        string bundlePath;
        string resPath = Path.Combine("Assets/Resources", path);
        if (typeof(T) == typeof(GameObject))
        {
            resPath = Path.ChangeExtension(resPath, "prefab");
        }
        //如果Bunble有这个资源从Bundle中加载.
        if (m_ResAbDic.TryGetValue(resPath, out bundlePath))
        {
            AssetBundle assetbundle;
            if (!m_BundleCache.TryGetValue(bundlePath, out assetbundle))
            {
                assetbundle = m_BundleCache[bundlePath] = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundlePath));
            }
            return assetbundle.LoadAsset<T>(resPath);
        }
        //如果Bundle中没有，从Resources目录中加载
        return Resources.Load<T>(path);
    }
}
