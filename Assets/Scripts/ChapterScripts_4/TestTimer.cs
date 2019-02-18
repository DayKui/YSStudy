using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TestTimer : MonoBehaviour
{

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0,60,100,40), "开始测试"))
        {
            StartCoroutine(StartGo()); 
        }
    }
    IEnumerator StartGo()
    {
        yield return new CustomWait(10f, 1f, delegate () {
            Debug.LogFormat("测试timer ：{0}", Time.time);

        });
    }
    
}
