using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GuiBase : MonoBehaviour,IPointerEnterHandler {
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnPointerEnter(PointerEventData eventData) {
        this.GetComponent<Image>().color = Color.blue;
    }
}
