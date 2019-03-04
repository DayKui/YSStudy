using System.Collections;
using UnityEngine;
using UnityEditor;

public class FindPath
{
    [MenuItem("Assets/Open PersistentDataPath")]
    static void Open()
    {
        EditorUtility.RevealInFinder(Application.persistentDataPath);//打开路径目录
    }
}
