using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRotate : MonoBehaviour {
    private ICanvasElement rotateTarget;

    public UIRotate(ICanvasElement rotateTarget) {
        this.rotateTarget = rotateTarget;
    }
    
    public void Rotate(float rotateAngle,float rotationTime) {
        rotateTarget.transform.Rotate(new Vector3(0,0,rotateAngle));
    }
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
