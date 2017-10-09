using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOnHover : OnHover {
    /// <summary>
    /// 是否是循环播放动画的
    /// </summary>
    public bool loop=true;

    /// <summary>
    /// 旋转的UI对象
    /// </summary>
    public GameObject ui;

    /// <summary>
    /// 旋转时间
    /// </summary>
    public float rotationTime=1;


    /// <summary>
    /// 当鼠标悬停在UI上的时候,进行旋转.
    /// </summary>
    public override void OnHovering() {
        base.OnHovering();
        ui.transform.Rotate(0,0,-360*(Time.deltaTime/rotationTime));
    }
}
