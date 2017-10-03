using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PassEventer : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler {

    //监听按下
    //监听点击

    //把事件透下去
    public void PassEvent<T>(PointerEventData data, ExecuteEvents.EventFunction<T> function)
        where T : IEventSystemHandler {
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll( data, results );
        GameObject current = this.gameObject;
        Debug.Log(results.Count);
        for(int i = 0; i < results.Count; i++) {
            if(current != results[i].gameObject) {
                ExecuteEvents.Execute( results[i].gameObject, data, function );
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        PassEvent( eventData, ExecuteEvents.pointerEnterHandler );
    }

    public void OnPointerExit(PointerEventData eventData) {
        PassEvent( eventData, ExecuteEvents.pointerEnterHandler );
    }
}
