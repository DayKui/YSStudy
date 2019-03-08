using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml;
using System.IO;
public class CreateXml {

    [MenuItem("XML/WriteXML")]
    static void WriteXml()
    {
        string xmlPath = Path.Combine(Application.dataPath,"test.xml");
        if (File.Exists(xmlPath))
        {
            File.Delete(xmlPath);
        }
        //创建XmlDocument
        XmlDocument xmlDoc = new XmlDocument();
        XmlDeclaration xmlDeclation = xmlDoc.CreateXmlDeclaration("1.0","UTF-8",null);
        xmlDoc.AppendChild(xmlDeclation);

        //节点中写入数据
        XmlElement root = xmlDoc.CreateElement("XmlRoot");
        xmlDoc.AppendChild(root);

        //循环写入三条数据
        for (int i = 0; i < 3; i++)
        {
            XmlElement record = xmlDoc.CreateElement("Record");
            record.SetAttribute("id",i.ToString());
            record.SetAttribute("username","雨凇mono");
            record.SetAttribute("password","123456");
            root.AppendChild(record);
        }
        //写入文件
        xmlDoc.Save(xmlPath);
        AssetDatabase.Refresh();
    }

    [MenuItem("XML/LoadXml")]
    static void LoadXml()
    {
        string xmlPath = Path.Combine(Application.dataPath, "test.xml");
        //xml文件只有存在才能读取
        if (File.Exists(xmlPath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlNode nodes = xmlDoc.SelectSingleNode("XmlRoot");
            foreach (XmlNode node in nodes.ChildNodes)
            {
                string id = node.Attributes["id"].Value;
                string username = node.Attributes["username"].Value;
                string password = node.Attributes["password"].Value;
                Debug.LogFormat("id={0} username={1} password={2}", id, username, password);
            }
        }
    }
}
