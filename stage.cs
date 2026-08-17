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
    private System.Random ran = new System.Random();
    protected List<GameObject> list = new List<GameObject>();
    
    void Start()
    {
        int kol = ran.Next(3, 10);
        for (int i = 0; i < kol; i++)
        {
            GameObject obj =  blockCreate.CreateObj();
            list.Add(obj);
        }
        Place(list);
    }

    public void Place(List<GameObject> objList)
    {
        Vector3 rotation = Vector3.zero;
        Vector2 curPozition = levelRules.position;
        int x = Convert.ToInt32(cam.orthographicSize);
        bool sideRight = true;
        foreach (GameObject obj in objList) {
            obj.transform.position = curPozition;
            obj.transform.eulerAngles = rotation;
            curPozition.x = sideRight ? ran.Next(1, x)*0.5f : ran.Next(-x, 1) * 0.5f;
            curPozition.y += ran.Next(1, x)*0.5f;
            rotation.z += 90*ran.Next(0, 4);
            sideRight = !sideRight;
        }
        curPozition.x += 3;
        lastPoz = curPozition;
    }
}
