using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GuideTexMove : MonoBehaviour
{
    //需要聚合的对象(例子中的Unity图标)
    public Image target;
    //Canvas对象
    public Canvas canvas;

    private Vector4 m_Center;
    private Material m_Material;
    private float m_Diameter; // 直径
    private float m_Current = 0f;

    Vector3[] corners = new Vector3[4];

    void Awake()
    {

        target.rectTransform.GetWorldCorners(corners);
        m_Diameter = Vector2.Distance(WordToCanvasPos(canvas, corners[0]), WordToCanvasPos(canvas, corners[2])) / 2f;

        float x = corners[0].x + ((corners[3].x - corners[0].x) / 2f);
        float y = corners[0].y + ((corners[1].y - corners[0].y) / 2f);

        Vector3 center = new Vector3(x, y, 0f);
        Vector2 position = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, center, canvas.GetComponent<Camera>(), out position);




        center = new Vector4(position.x, position.y, 0f, 0f);
        m_Material = GetComponent<Image>().material;
        m_Material.SetVector("_Center", center);



        (canvas.transform as RectTransform).GetWorldCorners(corners);
        for (int i = 0; i < corners.Length; i++)
        {
            m_Current = Mathf.Max(Vector3.Distance(WordToCanvasPos(canvas, corners[i]), center), m_Current);
        }

        m_Material.SetFloat("_Silder", m_Current);
    }


    float yVelocity = 0f;
    void Update()
    {
        float value = Mathf.SmoothDamp(m_Current, m_Diameter, ref yVelocity, 0.3f);
        if (!Mathf.Approximately(value, m_Current))
        {
            m_Current = value;
            m_Material.SetFloat("_Silder", m_Current);
        }
    }

    void OnGUI()
    {
        if (GUILayout.Button("Test"))
        {
            Awake();
        }
    }


    Vector2 WordToCanvasPos(Canvas canvas, Vector3 world)
    {
        Vector2 position = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out position);
        return position;
    }
}

