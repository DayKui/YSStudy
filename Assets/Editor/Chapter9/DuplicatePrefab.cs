using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class DuplicatePrefab : MonoBehaviour
{
    [MenuItem("Tool/DuplicateGameObject %#d")]
    static void DuplicateGameObject()
    {
        if (Selection.activeTransform)
        {
            Dictionary<string, Renderer> save = new Dictionary<string, Renderer>();

            //根据相对路径保存Renderer信息
            foreach (var renderer in Selection.activeTransform.GetComponentsInChildren<Renderer>())
            {
                string path = AnimationUtility.CalculateTransformPath(renderer.transform, Selection.activeTransform);
                save[path] = renderer;
            }
            //执行复制
            EditorApplication.ExecuteMenuItem("Edit/Duplicate");
            //还原烘焙信息
            foreach (var renderer in Selection.activeTransform.GetComponentsInChildren<Renderer>())
            {
                string path = AnimationUtility.CalculateTransformPath(renderer.transform, Selection.activeTransform);
                if (save.ContainsKey(path))
                {
                    renderer.lightmapIndex = save[path].lightmapIndex;
                    renderer.lightmapScaleOffset = save[path].lightmapScaleOffset;
                }
            }
        }
    }

}
