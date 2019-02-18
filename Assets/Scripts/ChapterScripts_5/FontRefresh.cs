using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FontRefresh : MonoBehaviour {

    //标记某个字体发生了重建
    private Font m_NeedRebuildFont = null;

    private void Start()
    {
        Font.textureRebuilt += delegate (Font font) { m_NeedRebuildFont = font; };
    }
    private void Update()
    {
        if (m_NeedRebuildFont)
        {
            //找到场景中所有的Text进行刷新；
            Text[] texts = GameObject.FindObjectsOfType<Text>();
            foreach (Text text in texts)
            {
                if (text.font==m_NeedRebuildFont)
                {
                    text.FontTextureChanged();
                }
            }
            m_NeedRebuildFont = null;
        }
    }
}
