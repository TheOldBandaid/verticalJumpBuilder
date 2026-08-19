using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class level : MonoBehaviour
{
    public stage stageInfo;
    private Vector2 position;

    void Start() {
        stageInfo.MakeStage();
        stageInfo.MakeStage();
    }

    public Vector2 Position()
    {
        position = stageInfo.lastPoz == Vector2.zero ? new Vector2(-1.5f, -2.5f) : stageInfo.lastPoz;
        return position;
    }

    //public void StagesOfCreation() { 
    //}

    //public void CamClean() {
    //    float camBottomLine = stageInfo.cam.ViewportToWorldPoint(Vector3.zero).y;
    //    if (camBottomLine > position.y)
    //    {}
    //}
}
