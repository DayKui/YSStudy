using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestSerDic
{

    [MenuItem("Excel/Load Dictionary")]
    static void SerializableDictionary()
    {
        SerializableDictionary<int, string> serializableDictionary = new SerializableDictionary<int, string>();
        serializableDictionary[100] = "雨松momo";
        serializableDictionary[200] = "好好学习";
        serializableDictionary[300] = "天天向上";
        string json = JsonUtility.ToJson(serializableDictionary);
        Debug.Log(json);

        serializableDictionary = JsonUtility.FromJson<SerializableDictionary<int, string>>(json);
        Debug.Log(serializableDictionary[100]);

    }

}
