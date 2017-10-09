using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using UnityEngine;
[Serializable]
public class User :ScriptableObject {
    [XmlAttribute] public string UserName;
    [XmlAttribute] public string NickName;
    public void SaveLocal() {
        
    }
}
