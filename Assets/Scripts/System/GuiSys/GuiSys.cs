using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;

public interface GuiRender {
    bool Render();

}
//当gui不固定的时候,以屏幕百分比的形式显示gui
public class GuiRect : GuiRender {
    private float width;
    private float height;
    public Vector2 centerPoint;
    public Vector2 leftTopPoint;
    protected bool guiFixed;
    public Rect Rect;

    public GuiRect(float w, float h, Vector2 lf, bool guiFixed) {


        this.width = w;
        this.height = h;
        leftTopPoint = lf;
        this.guiFixed = guiFixed;
        if(guiFixed) {
            Rect = new Rect( leftTopPoint.x, leftTopPoint.y, width, height );
        }
        else {
            Rect = new Rect(leftTopPoint.x*Screen.width,leftTopPoint.y*Screen.height,width*Screen.width,height*Screen.height);
        }

    }


    public GuiRect(float w, float h, float left, float top, bool guiFixed) : this( w, h, new Vector2( left, top ), guiFixed ) {

    }

    public void Refresh() {
        Rect.width = Screen.width * width;
        Rect.height = Screen.height * height;
    }
    public bool Render() {
        return false;
    }
}

public class GuiButton : GuiRect {
    public GuiButton(float w, float h, Vector2 lf, bool guiFixed, string content) : base( w, h, lf, guiFixed ) {
        this.Content = content;
    }

    public GuiButton(float w, float h, float left, float top, bool guiFixed, string content) : base( w, h, left, top, guiFixed ) {
        this.Content = content;
    }

    protected string Content { get; set; }

    public bool Render() {
        return GUI.Button( Rect, Content );
    }
}
public class GuiSys {

}
