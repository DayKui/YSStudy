using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBatch : MonoBehaviour {

    public GameObject[] datas;
	// Use this for initialization
	void Start () {
        StaticBatchingUtility.Combine(datas,gameObject);
	}
	
	
}
