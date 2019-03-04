using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsStudy : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Record record = new Record();
        record.stringValue = "雨松MOMO";
        record.intValue = 200;
        record.names = new List<string>() { "test1", "test2" };
        string json = JsonUtility.ToJson(record);
        try
        {
            PlayerPrefs.SetString("record", json);
        }
        catch (System.Exception err)
        {
            Debug.Log("Got: " + err);
        }
        //读取存档
        record = JsonUtility.FromJson<Record>(PlayerPrefs.GetString("record"));
        Debug.LogFormat("stringValue = {0} intValue={1}", record.stringValue, record.intValue);
    }
    //存档对象
    [System.Serializable]
    public class Record
    {
        public string stringValue;
        public int intValue;
        public List<string> names;
    }
}
