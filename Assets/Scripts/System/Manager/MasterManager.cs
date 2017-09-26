using System;
using System.Collections;
using System.Collections.Generic;
using Assets.System.Manager;
using UnityEngine;
using Object = UnityEngine.Object;

public class MasterManager :IManager {
    private Dictionary<string, IManager> managerSet = new Dictionary<string, IManager>();

    public int managerIdCount = 0;

    public static MasterManager GlobalMasterManager;

    public IManager RegisterManager(Type t) {
        IManager iManager = null;
        if (typeof(IManager).IsAssignableFrom(t)) {
            if (typeof(MonoBehaviour).IsAssignableFrom(t)) {
               GameObject go = new GameObject( "ActionManager" ); // 创建一个新的GameObject
               iManager = go.AddComponent(t) as IManager;
               Object.DontDestroyOnLoad(go);
            }
            else {
                var a = t.GetConstructors()[0];
                iManager = (IManager)a.Invoke( null );
            }


        }
        else {
        Debug.Log(t.Name +　"is not a subclass of "  + typeof(IManager).Name);

        }
        if (iManager != null) {
            RegisterExistedManager(iManager);
        }
        return iManager;
    }

    public IManager GetManager(string managerName) {
        return managerSet[managerName];
    }

    public IManager GetManager(Type t) {
        if (managerSet.ContainsKey(t.Name)) {
            return GetManager(t.Name);
        }
        Debug.Log("No such type manager");
        return null;
    }

    public void RegisterExistedManager(IManager m) {
        if (m != null) {
            if (managerSet.ContainsKey(m.GetType().ToString())) {
                Debug.Log("Error! Same manager  already exist :" + m.GetType().ToString());
            }
            else {
               
                managerSet.Add(m.GetType().Name, m);
                m.ManagerId = managerIdCount++;
            }
        }
        else {
            Debug.Log("Error! The Register Manager is Null");
        }
    }

    public MasterManager() {
   
    }


    public int ManagerId { get; set; }
    public string ManagerName { get; set; }
}
