using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAssetStudy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //必须要用utf8 格式保存
        Debug.Log(Resources.Load<TextAsset>("TestAsset").text);
    }
	
}
