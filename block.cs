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
    public Sprite sprite;
    private PolygonCollider2D form;
    public System.Random ran = new System.Random();

    public PolygonCollider2D Rectangle(GameObject obj, bool a) {
        form = obj.AddComponent<PolygonCollider2D>();
        float hight = ran.Next(1, 4) * 0.25f;
        float width = ran.Next(1, 4) * 0.25f;

        Vector2[] points = new Vector2[] {
            new Vector2(width, -hight),
            !a ? Vector2.zero : new Vector2(width, hight),
            new Vector2(-width, hight),
            new Vector2(-width, -hight)
        };

        form.points = points;
        return form;
    }

    public PolygonCollider2D Boards(GameObject obj)
    {
        PolygonCollider2D borderForm = obj.AddComponent<PolygonCollider2D>();
        int amount = ran.Next(1, form.points.Length);
        Vector2[] points = new Vector2[] {
        };

        borderForm.points = points;
        return borderForm;

    }

    public void Visual(GameObject obj, Sprite sprite)
    {
        MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
        Mesh mesh = form.CreateMesh(true, true);

        Material material = meshRenderer.material;
        material.mainTexture = sprite.texture;
        meshRenderer.material = material;

        Vector3[] vertices = mesh.vertices;
        Vector2[] dots = new Vector2[vertices.Length];
        for (int i = 0; i<vertices.Length; i++)
        {
            float x = vertices[i].x;
            float y = vertices[i].y;
            dots[i]= new Vector2(x, y);
        }

        mesh.uv = dots;
        meshFilter.mesh = mesh;
    }


    private void Start()
    {
        for (int i = 0; i<10; i++)
        {
            Vector2 poz = new Vector2(i-2, i-2);
            blockPrefab = new GameObject();
            blockPrefab.transform.parent = transform;
            transform.position = poz;

            bool type = ((ran.Next(0, 2)) != 1);

            Rectangle(blockPrefab, type);
            Visual(blockPrefab, sprite);
        }
        
    }
}