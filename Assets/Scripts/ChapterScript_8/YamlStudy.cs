using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YamlDotNet.RepresentationModel;
using System.IO;
public class YamlStudy : MonoBehaviour {

    private IDictionary<YamlNode, YamlNode> m_MappingData;
    private void Start()
    {
        //读取yaml字符串
        string document = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "yaml.txt"));
        var input = new StringReader(document);
        var yaml = new YamlStream();
        yaml.Load(input);

        //读取root点检节点
        Debug.Log(yaml.Documents.Count+"==yamlCount");
        var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
        m_MappingData = mapping.Children;
    }
    private void OnGUI()
    {
        GUILayout.Label(string.Format("<size=50>服务器列表:{0}</size>", m_MappingData["ServerList"]));
        GUILayout.Label(string.Format("<size=50>服务器端口:{0}</size>", m_MappingData["Port"]));
        GUILayout.Label(string.Format("<size=50>是否启动调试:{0}</size>", m_MappingData["Debug"]));
    }

}
