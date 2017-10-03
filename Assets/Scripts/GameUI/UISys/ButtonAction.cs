using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

class ButtonAction :OnHover {
    public float leftL = 0;
    public float rightL =  0;
    public float circleR = 0;
    public override void OnPointerExit(PointerEventData eventData) {
        base.OnPointerExit(eventData);
    }
    public override void OnPointerEnter(PointerEventData eventData) {
        Vector2 m2 = eventData.position;
        Vector2 nv = Camera.main.ScreenToWorldPoint(m2);
        Debug.Log(nv);
        base.OnPointerEnter(eventData);
    }
    public override void OnHovering() {
        base.OnHovering();
    }
}
