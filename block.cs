using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class block : MonoBehaviour
{
    private GameObject blockPrefab;
    // in other script there will be sprite changing, but for now just enter manually
    public Sprite sprite;
    private PolygonCollider2D form;
    private SpriteRenderer spriteRenderer;
    private SpriteMask mask;
    public System.Random ran = new System.Random();

    public PolygonCollider2D Rectangle(GameObject obj, bool a) {
        form = obj.AddComponent<PolygonCollider2D>();

        float hight = ran.Next(1, 4) * 0.25f;
        float width = ran.Next(1, 4) * 0.25f;
        form.pathCount = 1;

        Vector2[] points = new Vector2[4];
        points[0] = new Vector2(hight, width);
        points[1] = new Vector2(-hight, width);
        points[2] = new Vector2(-hight, -width);
        points[3] = new Vector2(hight, -width);
        

        if (!a)
        {
            points[ran.Next(0, 4)] = new Vector2(0, 0);
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

        mask = obj.AddComponent<SpriteMask>();
        mask.sprite = sprite;
        mask.bounds = form.bounds;
        mask.transform.position = new Vector3(0, 0, 0);
    }

    private void Start()
    {
        blockPrefab = new GameObject();
        // if type == false, form = triagle else rectangle
        // bool type = ((ran.Next(0, 2)) != 1);
        bool type = false;

        Rectangle(blockPrefab, type);
        Visual(blockPrefab);
        if (type)
        {

        }
        else
        {

        }
        blockPrefab.transform.position = new Vector3(0, 0, 0);
    }
}