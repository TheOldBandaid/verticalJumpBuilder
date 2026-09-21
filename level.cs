using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class level : MonoBehaviour
{
    public stage stageInfo;

    public int activeStage = 3;
    private Vector2 position;

    private float triggerY;
    Queue<List<GameObject>> queueStage = new Queue<List<GameObject>>();



    public Vector2 Position()
    {
        position = stageInfo.lastPoz == Vector2.zero ? new Vector2(-1.5f, -2.5f) : stageInfo.lastPoz;
        return position;
    }

    void Start() {
        for (int i = 0; i < activeStage; i++) {
            List<GameObject> list = stageInfo.CreateStage();
            stageInfo.Place(list);
            queueStage.Enqueue(list);
        }
        FixPosition();
    }

    private void Update()
    {
        float cameraTop = stageInfo.cam.transform.position.y
            + stageInfo.cam.orthographicSize;

        if (cameraTop > triggerY)
        {
            UpdateStage();
            FixPosition();
        }
    }

    public void FixPosition()
    {
        triggerY = position.y - stageInfo.cam.orthographicSize + 3f;
    }

    public void UpdateStage()
    {
        if (queueStage.Count == 0) return;
        List<GameObject> oldStage = queueStage.Dequeue();
        stageInfo.Place(oldStage);
        queueStage.Enqueue(oldStage);
    }

}
