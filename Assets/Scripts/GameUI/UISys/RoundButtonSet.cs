using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Image = UnityEngine.UI.Image;

/// <summary>
/// 圆形按钮集合
/// 
/// </summary>
public class RoundButtonSet : MonoBehaviour {
    public List<string> TextList;
    public Sprite sp;
    public Canvas ca;
    public float perc = 0.8f;
    private float litr = 10;
    private float bigr = 50;
    private int countNum = 0;
    private float leftSpace = 0f;
    private List<GameObject> circleGameObjects = new List<GameObject>();

    void Start () {
        countNum = TextList.Count;
        float eachSize = 1.0f / countNum * perc;
        leftSpace = 1.0f / countNum - eachSize;
        float shift = 0;
        var rectTrans = this.gameObject.GetComponent<RectTransform>();
        bigr = rectTrans.rect.width * rectTrans.localScale.x * 0.5f;
        litr = rectTrans.rect.width * rectTrans.localScale.x * 0.3f;


        GameObject go = null;
        foreach (string textInfo in TextList) {
            go  =  new GameObject( textInfo );

            go.AddComponent<Image>();
            go.GetComponent<Image>().sprite = sp;
            go.GetComponent<Image>().type  = Image.Type.Filled;
            go.GetComponent<Image>().fillAmount = eachSize;
            go.GetComponent<Image>().fillOrigin = (int) Image.Origin360.Top;
            go.GetComponent<Image>().color = new Color((shift+1)*0.2f, (shift + 1) * 0.2f, (shift + 1) * 0.2f );


            go.transform.SetParent(this.gameObject.transform);


            go.GetComponent<RectTransform>().anchoredPosition = new Vector2( 0, 0 );
            go.GetComponent<RectTransform>().localScale =  new Vector3(1f,1f,1f);
            go.GetComponent<RectTransform>().Rotate( 0, 0,  360  *　shift / countNum - 360 *leftSpace*0.5f );
       //      go.AddComponent<ButtonAction>();

            go.layer = LayerMask.NameToLayer("UI");
            

            shift += 1.0f;
            circleGameObjects.Add(go);
        }
  

    }

    public void ResetAllButton() {
        foreach(var gmo in circleGameObjects) {
            gmo.GetComponent<RectTransform>().localScale = new Vector3( 1, 1, 1 );
        }
        var rectTrans = this.gameObject.GetComponent<RectTransform>();
        bigr = rectTrans.rect.width * rectTrans.localScale.x * 0.5f;
    }
	void Update () {
	    Vector2 m2 = new Vector2(0,0);
 
        var  rectTransform = ca.transform as RectTransform;
        //获取当前屏幕的鼠标坐标
       
	    RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, ca.worldCamera, out m2);
	   // Debug.Log(m2);

        //判断是否在圆上
	    if (m2.magnitude > litr && m2.magnitude < bigr) {
	        float res = Mathf.Atan2(m2.y, m2.x) * Mathf.Rad2Deg;
	        res = res > 90 ? res : res + 360;
	        res = res - 90;
	        int resTarget = (int) (res / (360 / countNum));
	        DebugConsole.Log(res.ToString() + "," + (res - resTarget * 360 / countNum).ToString());


	        if (res - resTarget * 360 / countNum < leftSpace * 180 ||
	            res - resTarget * 360.0f / countNum > 360.0f / countNum - leftSpace * 180) {
                 ResetAllButton();
	        }
	        else {
	            circleGameObjects[(resTarget+1)%countNum].GetComponent<RectTransform>().localScale = new Vector3(1.05f, 1.05f, 1.05f);
                var rectTrans = this.gameObject.GetComponent<RectTransform>();
                bigr  = rectTrans.rect.width * rectTrans.localScale.x * 0.5f * 1.05f;
            }

	    }
	    else { 
	        ResetAllButton();
	    }
	}
}
