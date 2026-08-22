using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.U2D;
using UnityEditor;
using UnityEngine.UI;

public class block : MonoBehaviour
{
    public Material material1, material2;
    private PolygonCollider2D form;
    private PolygonCollider2D borderForm;
    public System.Random ran = new System.Random();

    public float hight, width;

    public PolygonCollider2D InnerForm(GameObject obj, bool a) {
        form = obj.AddComponent<PolygonCollider2D>();
        hight = ran.Next(1, 4) * 0.25f;
        width = ran.Next(1, 4) * 0.25f;
        Vector2[] points = new Vector2[a ? 4 : 3];

        points[0] = new Vector2(width, -hight);
        points[1] = new Vector2(-width, -hight);
        points[2] = new Vector2(-width, hight);
        if (a) { points[3] = new Vector2(width, hight); }

        form.points = points;
        return form;
    }

    public PolygonCollider2D BoardsForm(GameObject obj, int amount)
    {
        borderForm = obj.AddComponent<PolygonCollider2D>();
        Vector2[] points = new Vector2[amount];

        float x = form.points[0].x + 0.15f;
        float y = form.points[2].y + 0.15f;

        for (int i = 0; i<amount/2; ++i)
        {
            int modX = i==0 || i==3 ? 1 : -1;
            int modY = i<2 ? -1 :1;
            points[i] = form.points[i];
            points[amount - 1 - i] = new Vector2(x*modX, y*modY);
        }
        borderForm.isTrigger = true;

        borderForm.points = points;
        return borderForm;
    }

    public void Visual(GameObject obj)
    {
        MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();

        Mesh mesh1 = form.CreateMesh(false, false);
        Mesh mesh2 = borderForm.CreateMesh(false, false);
        uvGen(mesh1);
        uvGen(mesh2);

        Mesh mesh = new Mesh();

        CombineInstance[] combo = new CombineInstance[2];
        combo[0].mesh = mesh1;
        combo[1].mesh = mesh2;
        mesh.CombineMeshes(combo, false, false);
        
        meshRenderer.materials = new Material[] { material1, material2 };
        meshFilter.mesh = mesh;
    }

    private void uvGen(Mesh mesh)
    {
        Vector3[] vertices = mesh.vertices;
        Vector2[] uvs = new Vector2[vertices.Length];
        int changePivotX = Convert.ToInt32(hight * 4);
        int changePivotY = Convert.ToInt32(width * 4);
        Vector2 changePivot = new Vector2(ran.Next(0, changePivotX) * 0.25f, ran.Next(0, changePivotY) * 0.25f);

        for (int i = 0; i < vertices.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y) - changePivot;
        }

        mesh.uv = uvs;
    }

    public void Inner(GameObject obj)
    {
        bool type = ((ran.Next(0, 2)) != 1);
        InnerForm(obj, type);
    }

    public void Borders(GameObject obj)
    {
        int amount = ran.Next(2, form.points.Length + 1) * 2;
        BoardsForm(obj, amount);
    }


    public GameObject CreateObj()
    {
        GameObject obj = new GameObject("block");
        Inner(obj);
        Borders(obj);
        Visual(obj);
        return obj;
    }
}