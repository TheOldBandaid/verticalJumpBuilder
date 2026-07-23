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
    public Sprite sprite1, sprite2;
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
        int amount = ran.Next(2, form.points.Length)*2;
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

    public void Visual(GameObject obj, Sprite sprite, PolygonCollider2D collider)
    {
        MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
        Mesh mesh = collider.CreateMesh(false, false);
        meshRenderer.material.mainTexture = sprite.texture;
        meshFilter.mesh = mesh;
    }

    public void Inner(GameObject obj)
    {
        bool type = ((ran.Next(0, 2)) != 1);
        InnerForm(blockPrefab, type);
        Visual(blockPrefab, sprite1, form);
    }

    public void Borders(GameObject obj)
    {
        BoardsForm(blockPrefab);
        Visual(blockPrefab, sprite2, borderForm);
    }


    private void Start()
    {

        blockPrefab = new GameObject();
        Inner(blockPrefab);
        Borders(blockPrefab);
    }
}