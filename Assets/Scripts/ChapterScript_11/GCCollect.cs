using UnityEngine;
using System.IO;
using UnityEngine.Events;


public class GCCollect : MonoBehaviour 
{
	public GameObject g1;
	private AsyncOperation m_Operation;
	void Start()
	{
		GameObject.Destroy (g1);
		GC gc = GetComponent<GC> () ?? gameObject.AddComponent<GC> ();
		gc.UnloadUnusedAssets(delegate() {
			gc.UnloadUnusedAssets(delegate() {
				Debug.Log("彻底卸载掉资源!!");
			});
		});
	}

	public class GC : MonoBehaviour 
	{
		public  AsyncOperation m_Operation;
		public UnityAction m_Callback;

		public void UnloadUnusedAssets(UnityAction callback){
			m_Callback = callback;
			System.GC.Collect ();
			m_Operation = Resources.UnloadUnusedAssets();
		}

		void Update()
		{
			if (m_Operation !=null ) {
				if (m_Operation.isDone) {
					m_Operation = null;
					m_Callback ();
					//删除自身
					DestroyImmediate (this);
				}
			}
		}
	}
}
