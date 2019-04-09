using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SetUIByPost : AssetPostprocessor {

    //导入贴图钱
    void OnPreprocessTexture()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        if (textureImporter.assetPath.Contains("UI"))
        {
            TextureImporterPlatformSettings set = new TextureImporterPlatformSettings();
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.mipmapEnabled = false;
            //设置UI贴图在3个平台下的压缩格式以及大小
            textureImporter.SetPlatformTextureSettings("Standalone", 1024, TextureImporterFormat.RGBA32);
            textureImporter.SetPlatformTextureSettings("iPhone", 1024, TextureImporterFormat.RGBA32, 100, true);
            textureImporter.SetPlatformTextureSettings("Android", 1024, TextureImporterFormat.RGBA32, true);
        }
        else if (textureImporter.assetPath.Contains("Texture"))
        {
            textureImporter.textureType = TextureImporterType.Default;
            textureImporter.mipmapEnabled = true;
            //设置模型贴图在3个平台下的压缩格式以及大小
            textureImporter.SetPlatformTextureSettings("Standalone", 1024, TextureImporterFormat.DXT5);
            textureImporter.SetPlatformTextureSettings("iPhone", 1024, TextureImporterFormat.ASTC_RGBA_4x4, 100, true);
            textureImporter.SetPlatformTextureSettings("Android", 1024, TextureImporterFormat.ETC_RGB4, true);
        }
    }
}
