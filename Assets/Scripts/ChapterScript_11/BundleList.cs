using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BundleList : ScriptableObject
{

    public List<BundleData> bundleDatas = new List<BundleData>();

    //保存每个res路径对应的Bundle路径
    [System.Serializable]
    public class BundleData
    {
        public string resPath = string.Empty;
        public string bundlePath = string.Empty;
    }
}
