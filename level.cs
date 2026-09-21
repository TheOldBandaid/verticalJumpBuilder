using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class level : MonoBehaviour
{
    public stage stageInfo;

    public float start, end;
    private Vector2 position;



    public Vector2 Position()
    {
        position = stageInfo.lastPoz == Vector2.zero ? new Vector2(-1.5f, -2.5f) : stageInfo.lastPoz;
        return position;
    }

    void Start() {
        stageInfo.MakeStage();
        UpdateStage();
        FixPozition();
    }

    private void Update()
    {
        if ((stageInfo.cam.transform.position.y + stageInfo.cam.orthographicSize) % 2f < 0.1)
        {
            UpdateStage();
        }
    }

    public void FixPozition()
    {
        start = position.y;
        end = start + stageInfo.cam.orthographicSize;
    }

    public void UpdateStage()
    {
        float cameraTop = stageInfo.cam.transform.position.y
            + stageInfo.cam.orthographicSize;

        if (cameraTop > end)
        {
            stageInfo.MakeStage();
            FixPozition();
        }
    }

}
