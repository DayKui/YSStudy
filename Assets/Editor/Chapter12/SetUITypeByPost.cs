using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SetUITypeByPost : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;

        TextureImporterPlatformSettings setting = textureImporter.GetPlatformTextureSettings("Android");

        if (setting.format != TextureImporterFormat.RGBA32 && setting.format != TextureImporterFormat.ETC2_RGBA8)
        {
            textureImporter.SetPlatformTextureSettings("Android", 1024, TextureImporterFormat.ETC2_RGBA8, true);
        }
    }
}
