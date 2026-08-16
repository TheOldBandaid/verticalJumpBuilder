using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class stage : MonoBehaviour
{
    public Vector2 lastPoz;
    public block blockCreate;
    public level levelRules;
    public System.Random ran = new System.Random();
    public List<GameObject> list = new List<GameObject>();
    
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

        foreach (GameObject obj in objList) {
            obj.transform.position = curPozition;
            obj.transform.eulerAngles = rotation; 
        }
        curPozition.x += 3;
        lastPoz = curPozition;
    }
}
