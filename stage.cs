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
    private int kol;
    private System.Random ran = new System.Random();
    public List<GameObject> list = new List<GameObject>();
    
    void Start()
    {
        kol = ran.Next(7, 15);
        for (int i = 0; i < kol; i++)
        {
            GameObject obj =  blockCreate.CreateObj();
            list.Add(obj);
        }
        Place(list);
    }

    public void Place(List<GameObject> objList)
    {
        Vector2 curPozition = levelRules.Position();
        int cameraHight = Convert.ToInt32(cam.orthographicSize);

        float bottomY = curPozition.y;
        float stepY = (2f * cameraHight - Math.Abs(bottomY)) / kol;
        
        bool sideRight = true;

        foreach (GameObject obj in objList) {
            obj.transform.position = curPozition;
            obj.transform.eulerAngles =  new Vector3(0, 0, 90*ran.Next(1, 4));
            curPozition.x = sideRight ? 
                ran.Next(1, cameraHight) * cam.aspect :
                ran.Next(-cameraHight+1, 0)* cam.aspect;
            curPozition.y += stepY;
            sideRight = !sideRight;
        }

        curPozition.x += sideRight? 3 : -3;
        lastPoz = curPozition;
    }
}
