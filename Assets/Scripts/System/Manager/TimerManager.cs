using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Assets.Common.Algorithm;
using Assets.System.Manager;
using JetBrains.Annotations;
using UnityEngine;

public class TimerManager : MonoBehaviour,IManager {

    public PriorityQueue<Timer> listTimer = new PriorityQueue<Timer>(new Timer.TimerCompare());
    /// <summary>
    /// 添加计时器任务
    /// </summary>
    /// <param name="time">所添加的计时器</param>
    public void AddMission(Timer time) {
        listTimer.Push(time);
    }
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
    /// <summary>
    /// 每帧更新执行中的计时器.当计时器count数为0时,销毁计时器.
    /// </summary>
	void Update () {
	    int count = listTimer.Count;
	    if (count > 0) {
            foreach(var timer in listTimer) 
                timer.Update( Time.deltaTime );

	        while (listTimer.Count > 0 && listTimer.Top().Death) {
	            listTimer.Pop();
	 
	        }
        }

	}

    /// <summary>
    /// 管理器名称和ID
    /// </summary>
    public int ManagerId { get; set; }
    public string ManagerName { get; set; }
}
