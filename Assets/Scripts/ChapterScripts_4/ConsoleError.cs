using System;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleError : MonoBehaviour
{

    //错误详情
    private List<String> m_logEntries = new List<String>();
    //是否显示错误窗口
    private bool m_IsVisible = false;
    //窗口显示区域
    private Rect m_WindowRect = new Rect(0, 0, Screen.width, Screen.height);
    //窗口滚动区域
    private Vector2 m_scrollPositionText = Vector2.zero;

    private void Start()
    {
        //监听错误
        Application.logMessageReceived += (condition, stackTrace, type) =>
        {
            if (type == LogType.Exception || type == LogType.Error)
            {
                if (!m_IsVisible)
                {
                    m_IsVisible = true;
                }
                m_logEntries.Add(string.Format("{0}\n{1}", condition, stackTrace));
            }
        };

        //创建异常以及错误
        for (int i = 0; i < 10; i++)
        {
            Debug.LogError("momo");
        }
        int[] a = null;
        a[1] = 100;
    }

    void OnGUI()
    {
        if (m_IsVisible)
        {
            // GUILayout.BeginArea(new Rect(0, 100, 100, 100));
            //if (GUILayout.Button("显示错误日志"))
            //{
                //GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
                m_WindowRect = GUILayout.Window(0, m_WindowRect, ConsoleWindow, "Console");
              //  GUILayout.EndArea();
         //  }
         //  GUILayout.EndArea();
        }
    }

    //日志窗口
    void ConsoleWindow(int windowID)
    {
      //  GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Clear", GUILayout.MaxWidth(200)))
        {
            m_logEntries.Clear();
        }
        if (GUILayout.Button("Close", GUILayout.MaxWidth(200)))
        {
            //m_IsVisible = false;
        }
        GUILayout.EndHorizontal();

        m_scrollPositionText = GUILayout.BeginScrollView(m_scrollPositionText);


        foreach (var entry in m_logEntries)
        {
            Color currentColor = GUI.contentColor;
            GUI.contentColor = Color.red;
            GUILayout.TextArea(entry);
            GUI.contentColor = currentColor;
        }
        GUILayout.EndScrollView();
      //  GUILayout.EndArea();
    }
}
