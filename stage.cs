using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class stage : MonoBehaviour
{
    private level script;
    public int kol;
    public int x, y = 0;
    public System.Random ran = new System.Random();
    void Start()
    {
        kol = ran.Next(1, 5);
    }
}
