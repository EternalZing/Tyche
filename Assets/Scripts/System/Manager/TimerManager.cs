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

    public void AddMission(Timer time) {
        listTimer.Push(time);
    }
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
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

    public int ManagerId { get; set; }
    public string ManagerName { get; set; }
}
