using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PostModel : AssetPostprocessor {

    //导入模型前
    void OnPreprocessModel()
    {
        ModelImporter modelImporter = (ModelImporter)assetImporter;
        //禁止导入模型
        modelImporter.importMaterials = false;
        //设置模型动画
        modelImporter.animationType = ModelImporterAnimationType.Generic;
    }


    //导入模型后
    void OnPostprocessModel(GameObject g)
    {
        //自动生成Prefab
        PrefabUtility.CreatePrefab(string.Format("Assets/{0}.prefab", g.name), g);
    }
}
