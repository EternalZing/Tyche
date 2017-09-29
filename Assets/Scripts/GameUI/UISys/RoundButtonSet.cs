using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundButtonSet : MonoBehaviour {
    public List<string> TextList;
    public Sprite sp;
    public Canvas ca;
    public float perc = 0.8f;
    // Use this for initialization
    void Start () {
        List<GameObject> lis;
        int countNum = TextList.Count;
        float eachSize = 1.0f / countNum * perc;
        int shift = 0;
        foreach (string textInfo in TextList) {
            GameObject  go  = new GameObject(textInfo);
            go.AddComponent<Image>();
            go.GetComponent<Image>().sprite = sp;
            go.GetComponent<Image>().type  = Image.Type.Filled;
            go.GetComponent<Image>().fillAmount = eachSize;
            go.transform.Rotate(0,0,360*(float)shift/countNum);
            go.transform.SetParent(this.gameObject.transform);
            go.GetComponent<RectTransform>().anchoredPosition = new Vector2( 0, 0 );
            go.layer = LayerMask.NameToLayer("UI");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
