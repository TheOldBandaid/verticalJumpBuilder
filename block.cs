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
    private GameObject blockPrefab;
    public Material material1, material2;
    private PolygonCollider2D form;
    private PolygonCollider2D borderForm;
    public System.Random ran = new System.Random();

    public PolygonCollider2D InnerForm(GameObject obj, bool a) {
        form = obj.AddComponent<PolygonCollider2D>();
        float hight = ran.Next(1, 4) * 0.25f;
        float width = ran.Next(1, 4) * 0.25f;
        Vector2[] points = new Vector2[a ? 4 : 3];

        points[0] = new Vector2(width, -hight);
        points[1] = new Vector2(-width, -hight);
        points[2] = new Vector2(-width, hight);
        if (a) { points[3] = new Vector2(width, hight); }

        form.points = points;
        return form;
    }

    public PolygonCollider2D BoardsForm(GameObject obj)
    {
        borderForm = obj.AddComponent<PolygonCollider2D>();
        int amount = ran.Next(2, form.points.Length+1)*2;
        Vector2[] points = new Vector2[amount];

        float x = form.points[0].x + 0.2f;
        float y = form.points[2].y + 0.2f;

        for (int i = 0; i<amount/2; ++i)
        {
            int modX = i==0 || i==3 ? 1 : -1;
            int modY = i<2 ? -1 :1;
            points[i] = form.points[i];
            points[amount - 1 - i] = new Vector2(x*modX, y*modY);
        }

        borderForm.points = points;
        return borderForm;
    }

    public void Visual(GameObject obj)
    {
        MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
        Mesh mesh1 = form.CreateMesh(false, false);
        Mesh mesh2 = borderForm.CreateMesh(false, false);
        Mesh mesh = new Mesh();

        CombineInstance[] combo = new CombineInstance[2];
        combo[0].mesh = mesh1;
        combo[1].mesh = mesh2;
        mesh.CombineMeshes(combo, false, false);

        meshRenderer.materials = new Material[] { material1, material2 };
        meshFilter.mesh = mesh;
    }

    public void Inner(GameObject obj)
    {
        bool type = ((ran.Next(0, 2)) != 1);
        InnerForm(blockPrefab, type);
        // bouncing
    }

    public void Borders(GameObject obj)
    {
        BoardsForm(blockPrefab);
        // sticky
    }


    private void Start()
    {

        blockPrefab = new GameObject();
        Inner(blockPrefab);
        Borders(blockPrefab);
        Visual(blockPrefab);
    }
}