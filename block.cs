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
    private Material spriteMaterial;
    public Sprite sprite;
    private PolygonCollider2D form;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    
    public System.Random ran = new System.Random();
    public int corner = -1;

    public PolygonCollider2D Rectangle(GameObject obj, bool a) {
        form = obj.AddComponent<PolygonCollider2D>();

        float hight = ran.Next(1, 4) * 0.25f;
        float width = ran.Next(1, 4) * 0.25f;

        Vector2[] points = new Vector2[4];
        points[0] = new Vector2(hight, width);
        points[1] = new Vector2(-hight, width);
        points[2] = new Vector2(-hight, -width);
        points[3] = new Vector2(hight, -width);
        

        if (!a)
        {
            corner = ran.Next(0, 4);
            points[corner] = new Vector2(0, 0);
        }
        form.SetPath(0, points);
        return form;
    }

    public void Visual(GameObject obj, Sprite sprite)
    {
        meshFilter = obj.AddComponent<MeshFilter>();
        meshRenderer = obj.AddComponent<MeshRenderer>();

        Material spriteMat = new Material(Shader.Find("Sprites/Default"));
        spriteMat.mainTexture = sprite.texture;
        meshRenderer.material = spriteMat;

        Mesh mesh = form.CreateMesh(false, false);
        Vector3[] verticles = mesh.vertices;
        Vector2[] dots = new Vector2[verticles.Length];
        Vector2 spriteSize = form.bounds.size;
        Vector2 pointStart = new(0, 0);
        Bounds bounds = form.bounds;

        if (corner == -1) { corner = ran.Next(0, 4); }
        switch (corner)
        {
            case 0: 
                pointStart = new(bounds.max.x, bounds.min.y); break;
            case 1:
                pointStart = new(bounds.max.x, bounds.max.y); break;
            case 2:
                pointStart = new(bounds.min.x, bounds.max.y); break;
            case 3:
                pointStart = new(bounds.min.x, bounds.min.y); break;
            default:
                break;
        }


        for (int i = 0; i < verticles.Length; i++)
        {
            float x = (verticles[i].x / spriteSize.x );
            float y = (verticles[i].y / spriteSize.y );
            dots[i] = new Vector2(x, y);
        }
        mesh.uv = dots;
        meshFilter.mesh = mesh;
    }

    private void Start()
    {
        for (int i = 0; i<10; i++)
        {
            float x = 0;
            float y = 0;
            Vector2 poz = new Vector2(x+i, y+i);
            blockPrefab = new GameObject();
            blockPrefab.transform.parent = transform;
            transform.position = poz;

            bool type = ((ran.Next(0, 2)) != 1);

            Rectangle(blockPrefab, type);
            Visual(blockPrefab, sprite);
        }
        
    }
}