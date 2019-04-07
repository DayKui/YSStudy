using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Profiling;

public class LoadProfiler : MonoBehaviour {

    private void OnGUI()
    {
        if (GUILayout.Button("开始记录profiler"))
        {
            StartRecord();
        }
        if (GUILayout .Button("结束记录Profiler"))
        {
            StopRecord();
        }
    }

    public static void StartRecord()
    {
        string fileName = string.Format("ProfilerData_{0}.data", DateTime.Now.ToString("hhmmss"));
        if (Application.isEditor)
        {
            Profiler.logFile = Path.Combine(Application.dataPath+"/..",fileName);
        }
        else
        {
            Profiler.logFile = Path.Combine(Application.persistentDataPath,fileName);
        }
        Profiler.enabled = true;
        Profiler.enableBinaryLog = true;
    }
    public static void StopRecord()
    {
        UnityEngine.Profiling.Profiler.enabled = false;
        UnityEngine.Profiling.Profiler.enableBinaryLog = false;
        UnityEngine.Profiling.Profiler.logFile = "";
    }
}
