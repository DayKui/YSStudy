using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutionTest : MonoBehaviour {

    IEnumerator CreateCube()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position=Vector3.one*i;
            yield return new WaitForSeconds(1f);
        }
    }

    private Coroutine m_Coroutine = null;
    private void OnGUI()
    {
        if (GUILayout.Button("StartCoroutine"))
        {
            if (m_Coroutine!=null)
            {
                StopCoroutine(m_Coroutine);
            }
            m_Coroutine= StartCoroutine(CreateCube());
        }
        if (GUILayout.Button("StopCoroutine"))
        {
            if (m_Coroutine!=null)
            {
                StopCoroutine(m_Coroutine);//都可以停止
               // StopCoroutine(CreateCube()); 无法停止携程
              //  StopCoroutine("CreateCube");//无法停止不是以名字开启的携程
            }
        }
    }
}
