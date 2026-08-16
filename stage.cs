using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage : MonoBehaviour
{
    public block script;
    public int kol;
    public System.Random ran = new System.Random();
    void Start()
    {
        kol = ran.Next(3, 10);
        for (int i = 0; i < kol; i++)
        {
            Vector3 position = new Vector3(i, i, 0);
            GameObject obj =  script.CreateObj(position);
        }
    }
}
