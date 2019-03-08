using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PrefabLightmap : MonoBehaviour
{

    public int lightmapIndex;
    public Vector4 lightmapScaleOffset;

    void Awake()
    {
        //Prefab实例化后赋值
        Renderer renderer = GetComponent<Renderer>();
        if (renderer)
        {
            renderer.lightmapIndex = lightmapIndex;
            renderer.lightmapScaleOffset = lightmapScaleOffset;
        }
    }
#if UNITY_EDITOR
    [MenuItem("GameObject/Light/ToPrefab")]
    static void ToPrefab()
    {
        //确保选择一个Hierarchy视图下的游戏对象
        if (Selection.activeTransform)
        {
            Renderer renderer = Selection.activeTransform.GetComponent<Renderer>();
            //确保有renderer组件
            if (renderer)
            {

                PrefabLightmap prefabLightmap = Selection.activeTransform.GetComponent<PrefabLightmap>();
                if (!prefabLightmap)
                {
                    prefabLightmap = Selection.activeTransform.gameObject.AddComponent<PrefabLightmap>();
                }
                prefabLightmap.lightmapIndex = renderer.lightmapIndex;
                prefabLightmap.lightmapScaleOffset = renderer.lightmapScaleOffset;

                Object prefab = PrefabUtility.GetPrefabParent(renderer.gameObject);//获取这个物体在project中的源prefab
                                                                                   //如果有Prefab文件就更新，没有就创建新的                                                                  
                if (prefab)
                {
                    PrefabUtility.ReplacePrefab(Selection.activeTransform.gameObject, prefab, ReplacePrefabOptions.ConnectToPrefab);
                }
                else
                {
                    PrefabUtility.CreatePrefab(string.Format("Assets/Resources/{0}.prefab", Selection.activeTransform.name), Selection.activeTransform.gameObject, ReplacePrefabOptions.ConnectToPrefab);
                }
            }
        }
    }
#endif
}
