using UnityEngine;

public class ChangeLightMap : MonoBehaviour
{
    //烘培贴图1
    public Texture2D lightmap1;
    //烘培贴图2
    public Texture2D lightmap2;

    public Texture2D lightMap3;
    void OnGUI()
    {
        if (GUILayout.Button("<size=50>lightmap1</size>"))
        {
            LightmapData data = new LightmapData();
            data.lightmapColor = lightmap1;

            LightmapData data1 = new LightmapData();
            data.lightmapColor = lightMap3;
            LightmapSettings.lightmaps = new LightmapData[2] { data, data1 };
        }

        if (GUILayout.Button("<size=50>lightmap2</size>"))
        {
            LightmapData data = new LightmapData();
            data.lightmapColor = lightmap2;

            LightmapData data1 = new LightmapData();
            data.lightmapColor = lightMap3;
            LightmapSettings.lightmaps = new LightmapData[2] { data,data1 };
        }
    }
}
