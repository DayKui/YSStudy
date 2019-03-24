using System.Collections;
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
public class TestRecordUtil : MonoBehaviour
{
    void Start()
    {
        Setting setting = new Setting();
        setting.stringValue = "测试字符串";
        setting.intValue = 10000;

        Setting setting1 = new Setting();
        setting1.stringValue = "增加测试字符串";
        setting1.intValue = 20000;

        SettArray array = new SettArray();
        array.setList.Add(setting);
        array.setList.Add(setting1);

        RecordUtil.Set("setting", JsonUtility.ToJson(array));

        string setting2 = "添加第二条数据了。。。。";
        RecordUtil.Set("setting2", setting2);
    }

    private Setting m_Setting = null;
    string m_StringSeting = null;
    private string m_Setting2 = string.Empty;
    [SerializeField]
    private List<Setting> setList = new List<Setting>();
    void OnGUI()
    {
        if (GUILayout.Button("<size=50>获取存档</size>"))
        {
            m_StringSeting = RecordUtil.Get("setting");
            //m_Setting = JsonUtility.FromJson<Setting> (RecordUtil.Get ("setting"));
        }
        if (!string.IsNullOrEmpty(m_StringSeting))
        {
            GUILayout.Label(string.Format("<size=50> {0} </size>", m_StringSeting));
        }
        if (!string.IsNullOrEmpty(m_StringSeting))
        {
            SettArray set = JsonUtility.FromJson<SettArray>(m_StringSeting);
            GUILayout.Label(string.Format("<size=50>成员数量:{0},第一个数据{1}{2}，第二个数据{3}{4}/size>",
                set.setList.Count, set.setList[0].intValue, set.setList[0].stringValue, set.setList[1].intValue, set.setList[1].stringValue));
        }
        if (GUILayout.Button("<size=50>显示第二条设置数据</size>"))
        {
            m_Setting2 = RecordUtil.Get("setting2");
        }
        if (!string.IsNullOrEmpty(m_Setting2))
        {
            GUILayout.Label(string.Format("<size=50> {0}</size>", m_Setting2));
        }
        if (GUILayout.Button("<size=50>删除setting存档</size>"))
        {
            RecordUtil.Delete("setting");
        }
    }


    void OnApplicationPause(bool pauseStatus)
    {
        //当游戏即将进入后台时，保存存档
        if (pauseStatus)
        {
            RecordUtil.Save();
        }
    }

}

[System.Serializable]
class Setting
{
    public string stringValue;
    public int intValue;
}

[System.Serializable]
class SettArray
{
    public List<Setting> setList = new List<Setting>();
}
