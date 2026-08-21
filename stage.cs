using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class stage : MonoBehaviour
{
    public Vector2 lastPoz;
    public Camera cam;
    public block blockCreate;
    public level levelRules;
    private int kol = 1;
    private System.Random ran = new System.Random();
    public List<GameObject> list = new List<GameObject>();


    public void FillList() {
        kol = ran.Next(6, 13);
        for (int i = 0; i < kol; i++)
        {
            GameObject obj = blockCreate.CreateObj();
            list.Add(obj);
        }
    }
    
    public void MakeStage()
    {
        int maxAmount = 40;
        int start = list.Count;
        if (list.Count < maxAmount)
        {
            FillList();
            Place(list.GetRange(start, kol));
        }
        else {
            start = ran.Next(15, list.Count);
            kol = ran.Next(7, 15);
            Place(list.GetRange(start-kol, kol));
        }
    }



    public void Place(List<GameObject> objList)
    {
        Vector2 curPozition = levelRules.Position();
        int cameraHight = Convert.ToInt32(cam.orthographicSize);
        float stepY = (2f * cameraHight) / objList.Count;
        
        bool sideRight = true;

        foreach (GameObject obj in objList) {
            obj.transform.position = curPozition;
            obj.transform.eulerAngles =  new Vector3(0, 0, 90*ran.Next(1, 4));
            curPozition.x = sideRight ? 
                ran.Next(1, cameraHight) * cam.aspect :
                ran.Next(-cameraHight+1, 0)* cam.aspect;
            if (sideRight) { obj.transform.Rotate(0, 180, 0); }
            curPozition.y += stepY;
            sideRight = !sideRight;
        }

        curPozition.x += sideRight? 3 : -3;
        lastPoz = curPozition;
    }
}
