using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class SerializeDict : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<Sprite> m_Values = new List<Sprite>();
    [SerializeField]
    private List<string> m_Keys = new List<string>();

    public Dictionary<string, Sprite> spriteDic = new Dictionary<string, Sprite>();

    public void OnAfterDeserialize()
    {
        Debug.Log("反序列化");
        //反序列化
        spriteDic.Clear();
        if (m_Keys.Count != m_Values.Count)
        {
            Debug.LogError("m_Keys and m_Values 长度不匹配!!!");
        }
        else
        {
            for (int i = 0; i < m_Keys.Count; i++)
            {
                spriteDic[m_Keys[i]] = m_Values[i];
            }
        }
    }

    public void OnBeforeSerialize()
    {
        m_Keys.Clear();
        m_Values.Clear();
        foreach (KeyValuePair <string,Sprite>pair in spriteDic)
        {
            m_Keys.Add(pair.Key);
            m_Values.Add(pair.Value);
        }
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(SerializeDict))]
    public class ScriptInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            SerializedProperty propertyKey = serializedObject.FindProperty("m_Keys");
            SerializedProperty propertyValue = serializedObject.FindProperty("m_Values");

            int size = propertyKey.arraySize;

            GUILayout.BeginVertical();
            for (int i = 0; i < size; i++)
            {
                GUILayout.BeginHorizontal();
                SerializedProperty key = propertyKey.GetArrayElementAtIndex(i);
                SerializedProperty value = propertyValue.GetArrayElementAtIndex(i);
                key.stringValue = EditorGUILayout.TextField("key",key.stringValue);
                value.objectReferenceValue = EditorGUILayout.ObjectField("value",value.objectReferenceValue,typeof(Sprite),false);
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("+"))
            {
                (target as SerializeDict).spriteDic[size.ToString()] = null;
            }
            GUILayout.EndHorizontal();
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}
