using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.IO;

public class Script_10_02 : MonoBehaviour
{

    public AudioSource source;

    public AudioClip m_Clip;

    void Start()
    {
        source.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
        source.Play();

    }

    void OnGUI()
    {
        if (GUILayout.Button("<size=50>开始录音</size>"))
        {
            m_Clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
        }
        if (GUILayout.Button("<size=50>结束录音</size>"))
        {
            if (m_Clip)
            {
                Microphone.End("Built-in Microphone");
            }
        }

        if (GUILayout.Button("<size=50>播放保存录音</size>"))
        {
            if (m_Clip)
            {
                source.clip = m_Clip;
                source.Play();
            }
        }
    }

}
