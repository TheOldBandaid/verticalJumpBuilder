using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System;
using UnityEngine;

public class block : MonoBehaviour
{
    public GameObject blockPrefab;
    System.Random ran = new System.Random();

    public PolygonCollider2D Form(bool a) {
        PolygonCollider2D form = GetComponent<PolygonCollider2D>();

        float hight = ran.Next(1, 4) * 0.25f;
        float width = ran.Next(1, 4) * 0.25f;
        form.points[0] = new Vector2(hight, width);
        form.points[1] = new Vector2(hight, -width);
        form.points[2] = new Vector2(-hight, width);
        form.points[3] = new Vector2(-hight, -width);
        if (a == false)
        {
            form.points[ran.Next(0, 4)] = new Vector2(0, 0);
        }

        return form;
    }

    void Start()
    {
        if (Form(true))
        {

        }
        else { 
        }
    }
}
