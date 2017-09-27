using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonLoginReact : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	// Use this for initialization
    public GameObject ui;
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerEnter(PointerEventData eventData) {
        Animator animator = ui.GetComponent<Animator>();
        animator.SetInteger("state",1);
    }

    public void OnPointerExit(PointerEventData eventData) {
        Animator animator = ui.GetComponent<Animator>();
        animator.SetInteger( "state", 0 );
    }
}
