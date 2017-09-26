using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.System.Manager;
using UnityEditor;
using UnityEngine;

/*class ActionUnit {
    public ActionUnit(Action<object> action, Dictionary<string, object> dicInfo) {
        this.Action = action;
        this.DicInfo = dicInfo;
    }
    public ActionUnit(Action<object> action) {
    }

    public Action<object> Action { get; set; }

    public Dictionary<string, object> DicInfo { get; set; }
}*/


public class ActionManager : MonoBehaviour,IManager {
    class ActionRequest {
        public string name;
        public object dic;
        public ActionRequest(string name, object dic) {
            this.name = name;
            this.dic = dic;
        }
    }

    public Dictionary<string, Action<object>> ActionSet  = new Dictionary<string, Action<object>>();

    private Queue<ActionRequest> ActionQueue  = new Queue<ActionRequest>();
    public void RegisterAction(string actionName,Action<object> act) {
        if(ActionSet.ContainsKey(actionName)==false)
            ActionSet.Add(actionName,act);
        else 
            ActionSet[actionName] += act;
    }

    public void DoAction(string s,object obj) {
        this.ActionQueue.Enqueue(new ActionRequest(s,obj));
    }
    void Init() {
        
    }
    // Use this for initialization
    void Start () {
	    
	}

    private  void DeAction() {
        ActionRequest actionRequst = ActionQueue.Dequeue();
        Action<object> temp = ActionSet[actionRequst.name];
       // Debug.Log("deaction");
        temp(actionRequst.dic);
    }
	// Update is called once per frame
	void Update () {

	    while(ActionQueue.Count!=0)
            DeAction();
	}

    public int ManagerId { get; set; }
    public string ManagerName { get; set; }
}
