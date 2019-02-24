using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParticleScale : MonoBehaviour {

    struct ScaleData
    {
        public Transform transform;
        public Vector3 beginScale;
    }

    const float DESIGN_WIDTH = 1080f;
    const float DESIGN_HEIGHT = 1920f;//开发时的分辨率宽,高

    private Dictionary<Transform, ScaleData> m_ScaleData = new Dictionary<Transform, ScaleData>();

    private void Start()
    {
        
    }

    void Refresh()
    {
        float designScale = DESIGN_WIDTH / DESIGN_HEIGHT;
        float scaleRate = (float)Screen.width / (float)Screen.height;

        foreach (ParticleSystem p in transform.GetComponentsInChildren<ParticleSystem>(true))
        {
            if (!m_ScaleData.ContainsKey(p.transform))
            {
                m_ScaleData[p.transform] = new ScaleData() { transform = p.transform, beginScale = p.transform.localScale };
            }
        }
        foreach (var item in m_ScaleData)
        {
            if (scaleRate < designScale)
            {
                float scaleFactor = scaleRate / designScale;
                item.Value.transform.localScale = item.Value.beginScale * scaleFactor;
            }
            else
            {
                item.Value.transform.localScale = item.Value.beginScale;
            }
        }
    }

    private void OnTransformChildrenChanged()
    {
        Refresh();
    }
#if UNITY_EDITOR
    //编辑模式下修改分辨率在后Update中刷新
    private void Update()
    {
        Refresh();
    }
#endif
}
