using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MyEvent : UnityEvent<int, string> { }

public class EventStudy : MonoBehaviour
{
    public UnityAction<int, string> action1;
    public UnityAction<int, string> action2;
    public MyEvent myEvent = new MyEvent();

    public void RunMyEvent1(int a, string b)
    {
        Debug.Log(string.Format("RunMyEvent1 ,{0} , {1}", a, b));
    }
    public void RunMyEvent2(int a, string b)
    {
        Debug.Log(string.Format("RunMyEvent2 ,{0} , {1}", a, b));
    }

    void Start()
    {
        //也可以使用+=，但是+=执行多次没有-=就会有隐患
        action1 = RunMyEvent1;
        action2 = RunMyEvent2;

        myEvent.AddListener(action1);
        myEvent.AddListener(action2);

        //如果需要删除的话就执行Remove
        //		myEvent.RemoveListener (action1);
        //		myEvent.RemoveListener (action2);
        //		myEvent.RemoveAllListeners ();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("按下键盘A");
            action1.Invoke(0, "a");
            action2.Invoke(1, "b");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("按下键盘B");
            myEvent.Invoke(100, "a & b");
        }

    }
}

