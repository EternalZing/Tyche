using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer  {
    protected float leftTime;
    protected float totalTime;
    private bool counting;
    private bool death;
    public Action<object> timerAction;
    private object actionList;
    public bool Counting {
        get {
            return counting;
        }
    }

    public class TimerCompare : IComparer<Timer> {
        public int Compare(Timer x, Timer y) {
            if (x.leftTime > y.leftTime) return 1;
            if (x.leftTime == y.leftTime) return 0;
              return -1;
            
        }
    }
    public bool Death {
        get {
            return death;
        }
    }

    public object ActionList {
        get {
            return actionList;
        }

        set {
            actionList = value;
        }
    }

    public object ActionList1 {
        get {
            return actionList;
        }

        set {
            actionList = value;
        }
    }

    public Timer(float totalTime) {
        this.totalTime = totalTime;
        this.leftTime = totalTime;
        death = false;

    }
    
    public void start() {
        counting = true;
       death = false;
        var tm = MasterManager.GlobalMasterManager.GetManager( typeof( TimerManager ) ) as TimerManager;
        tm.AddMission(this);
    }

    public void start(float f) {
        totalTime = f;
        leftTime = f;
        start();

    }

    public void stop() {
        counting = false;
    }

    public void SetAction(Action<object> a) {
        timerAction = a;
    }
    public void Update(float time) {
        if (Counting == true) {
            leftTime -= time;
            if(leftTime <= 0) {
                this.counting = false;
                this.death = true;
                timerAction(actionList);
            }
        }
    }
}
