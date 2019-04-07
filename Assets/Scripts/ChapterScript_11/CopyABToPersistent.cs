using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CopyABToPersistent : MonoBehaviour
{

    IEnumerator Start()
    {

        string path = Path.Combine(Application.streamingAssetsPath, "cube.unity3d");

        //下载Bundle
        WWW www = new WWW("file://" + path);
        yield return null;
        string name = Path.GetFileName(path);
        string filePath = Path.Combine(Application.persistentDataPath, name);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        //下载结束写入本地
        File.WriteAllBytes(filePath, www.bytes);
        Debug.Log(filePath);

        //从硬盘中读取Bundle
        AssetBundle assetbundle = AssetBundle.LoadFromFile(filePath);
        //从Bundle中读取资源
        GameObject prefab = assetbundle.LoadAsset<GameObject>("Cube");
        //实例化资源
        GameObject.Instantiate<GameObject>(prefab);
    }
}
