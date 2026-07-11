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

    
    public System.Random ran = new System.Random();
    public int corner = -1;

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

    public void Visual(GameObject obj, Sprite sprite)
    {
        //SpriteRenderer spriteRenderer = obj.AddComponent<SpriteRenderer>();
        //spriteRenderer.sprite = sprite;

        //spriteRenderer.spriteSortPoint = SpriteSortPoint.Pivot;

        //Vector2[] spritePoints = form.points;
        //Vector2[] index = form.GetPath(0);

        //sprite.OverrideGeometry(spritePoints, index);
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