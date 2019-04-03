using UnityEngine;
using UnityEngine.Profiling;
using System.IO;
using System;

public class TestResAB : MonoBehaviour
{
    void Start()
    {

        GameObject.Instantiate<GameObject>(Assets.LoadAsset<GameObject>("Cube"));
        GameObject.Instantiate<GameObject>(Assets.LoadAsset<GameObject>("Cube1"));
    }
}
