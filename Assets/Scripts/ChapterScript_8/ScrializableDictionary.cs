using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializableDictionary<K, V> : ISerializationCallbackReceiver
{
    [SerializeField]
    private List<K> m_keys;
    [SerializeField]
    private List<V> m_values;

    private Dictionary<K, V> m_Dictionary = new Dictionary<K, V>();

    public V this[K key]
    {
        get
        {
            if (!m_Dictionary.ContainsKey(key))
                return default(V);
            return m_Dictionary[key];
        }
        set
        {
            m_Dictionary[key] = value;
        }
    }

    public void OnAfterDeserialize()
    {
        int length = m_keys.Count;
        m_Dictionary = new Dictionary<K, V>();
        for (int i = 0; i < length; i++)
        {
            m_Dictionary[m_keys[i]] = m_values[i];
        }
        m_keys = null;
        m_values = null;
    }

    public void OnBeforeSerialize()
    {
        m_keys = new List<K>();
        m_values = new List<V>();

        foreach (var item in m_Dictionary)
        {
            m_keys.Add(item.Key);
            m_values.Add(item.Value);
        }
    }
}