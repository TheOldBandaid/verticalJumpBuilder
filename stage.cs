using System;
using System.Collections.Generic;
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
        kol = ran.Next(4, 13);
        for (int i = 0; i < kol; i++)
        {
            GameObject obj = blockCreate.CreateObj();
            list.Add(obj);
        }
    }
    
    public void MakeStage()
    {
        int start = list.Count;
        FillList();
        Place(list.GetRange(start, kol));
    }



    public void Place(List<GameObject> objList)
    {
        Vector2 curPozition = levelRules.Position();
        int cameraHight = Convert.ToInt32(cam.orthographicSize);
        float stepY = (2f * cameraHight) / list.Count;
        
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
        lastPoz = curPozition;
    }
}
