using UnityEngine;
using System.Collections;
/// <summary>
/// 
/// 旧代码,捕捉相机位置
/// </summary>
public class CameraCatcher : MonoBehaviour {
    private Vector3 offset = new Vector3(0 ,0,-2 );//相机相对于玩家的位置
    private Transform target;
    public float speed = 5;
    private int camereType = 1;
    // Use this for initialization
    void Start() {
        Transform hero = GameObject.FindGameObjectWithTag( "PlayerHero" ).transform;
        GameObject go = new GameObject( "CameraTarget" );
        go.transform.parent = hero;
        go.transform.localPosition =  new Vector3(0,4,0);
        target = go.transform;
    }
    // Update is called once per frame
    void Update() {
        switch (camereType) {
            case 1: {
                    this.gameObject.transform.position = target.position + offset;
                    this.gameObject.transform.LookAt(target.transform);
                    break;
            }
        }
    }
}