using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.U2D;
using UnityEditor;

public class block : MonoBehaviour
{
    private GameObject blockPrefab;
    public Sprite sprite;
    private PolygonCollider2D form;
    private SpriteRenderer spriteRenderer;
    
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
            corner = ran.Next(1, 4);
            points[corner] = new Vector2(0, 0);
        }
        form.SetPath(0, points);
        return form;
    }

    public void Visual(GameObject obj)
    {
        spriteRenderer = obj.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
   



        if (corner != -1)
        {
            corner = corner switch { 0 => 2, 1 => 3, 2 => 0, 3 => 1, _ => -1};
        }
        else
        {
            corner = ran.Next(1, 4);
        }

    }

    private void Start()
    {
        blockPrefab = new GameObject();
        // if type == false, form = triagle else rectangle
        bool type = ((ran.Next(0, 2)) != 1);

        Rectangle(blockPrefab, type);
        Visual(blockPrefab);
    }
}