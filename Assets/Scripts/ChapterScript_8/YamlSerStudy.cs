using System.Collections.Generic;
using UnityEngine;
using YamlDotNet.Serialization;

public class YamlSerStudy : MonoBehaviour
{

    private void Start()
    {
        //创建对象
        Data data = new Data();
        data.name = "雨松momo";
        data.password = "123456";
        data.list = new List<string>() { "a", "b", "c" };

        //序列化yaml字符串
        Serializer serializer = new Serializer();
        string yaml = serializer.Serialize(data);
        Debug.LogFormat("serializer : \n{0}", yaml);

        //反序列化成类对象
        Deserializer deserializer = new Deserializer();
        Data data1 = deserializer.Deserialize<Data>(yaml);
        Debug.LogFormat("deserializer : name={0} password={1}", data1.name, data1.password);
    }


    class Data
    {
        public string name { get; set; }
        public string password { get; set; }
        public List<string> list { get; set; }
    }

}
