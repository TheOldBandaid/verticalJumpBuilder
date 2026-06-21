using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    // in other script there will be sprite changing, but for now just enter manually
    public Sprite sprite;
    public PolygonCollider2D form;
    private SpriteRenderer spriteRenderer;
    private SpriteMask mask;
    public System.Random ran = new System.Random();

    public PolygonCollider2D Rectangle(bool a) {
        form = GetComponent<PolygonCollider2D>();

        float hight = ran.Next(1, 4) * 0.25f;
        float width = ran.Next(1, 4) * 0.25f;

        form.points[0] = new Vector2(hight, width);
        form.points[1] = new Vector2(hight, -width);
        form.points[2] = new Vector2(-hight, width);
        form.points[3] = new Vector2(-hight, -width);

        if (!a)
        {
            form.points[ran.Next(0, 4)] = new Vector2(0, 0);
        }
        return form;
    }

    public void Visual(bool a)
    {
        spriteRenderer =  GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = sprite;
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

        
    }

    public GameObject Form()
    {
        // if type == false, form = triagle else rectangle
        bool type = ((ran.Next(0, 2)) != 1);
        
        Rectangle(type);
        if (type)
        {

        }
        else
        {

        }
        return blockPrefab;
    }

    private void Start()
    {
        
    }
}
