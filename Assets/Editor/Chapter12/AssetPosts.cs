using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetPosts:AssetPostprocessor
{
   //导入声音前
    void OnPreprocessAudio()
    {
        AudioImporter audioImporter = (AudioImporter)assetImporter;
        Debug.Log("导入音效，压缩前" + audioImporter.name);
    }
    //导入动画前
    void OnPreprocessAnimation()
    {
        ModelImporter modelImporter = (ModelImporter)assetImporter;
        Debug.Log("导入动画，压缩前" + modelImporter.name);
    }
    //导入模型前
    void OnPreprocessModel()
    {
        ModelImporter modelImporter = (ModelImporter)assetImporter;
        Debug.Log("导入模型，压缩前" + modelImporter.name);
    }
    //导入贴图前
    void OnPreprocessTexture()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        Debug.Log("导入贴图，压缩前" + textureImporter.name);
    }
    //导入声音后
    void OnPostprocessAudio(AudioClip clip)
    {
        Debug.Log(AssetDatabase.GetAssetPath(clip));
    }
    //导入模型后
    void OnPostprocessModel(GameObject g)
    {
        Debug.Log(AssetDatabase.GetAssetPath(g));
    }
    //导入材质后
    void OnPostprocessMaterial(Material material)
    {
        Debug.Log(AssetDatabase.GetAssetPath(material));
    }
    //导入精灵后
    void OnPostprocessSprites(Texture2D texture, Sprite[] sprites)
    {
        Debug.Log("Sprites: " + sprites.Length);
    }
    //导入贴图
    void OnPostprocessTexture(Texture2D texture)
    {
        Debug.Log("Texture2D: (" + texture.width + "x" + texture.height + ")");
    }

}
