using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private int hovered = 0;
	// Use this for initialization
    /// <summary>
    /// 当鼠标悬停在对象上时,每次Update所执行的函数,需要的时候重载这个函数
    /// </summary>
    public virtual void OnHoverTriggered() {
        
    }
    /// <summary>
    /// 当鼠标离开UI时,执行的函数,需要的时候重载这个函数
    /// </summary>
    public virtual void OnHoverLeave() {
        
    }

    /// <summary>
    /// 鼠标进入UI时,执行的函数.
    /// </summary>
    public virtual void OnHovering() {
        
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(hovered==1)
		    this.OnHovering();
	}

    /// <summary>
    /// 鼠标进入,执行OnHoverTriggered
    /// </summary>
    /// <param name="eventData"></param>
    public virtual void OnPointerEnter(PointerEventData eventData) {
        this.hovered = 1;
        this.OnHoverTriggered();
    }
    /// <summary>
    /// 鼠标离开,执行OnHoverLeave
    /// </summary>
    /// <param name="eventData"></param>
    public virtual void OnPointerExit(PointerEventData eventData) {
        this.hovered = 0;
       this.OnHoverLeave();
    }
}
