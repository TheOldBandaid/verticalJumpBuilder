using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class level : MonoBehaviour
{
    public Vector2 position;
    public stage stageInfo;
    void Start()
    {
        position = stageInfo.lastPoz == Vector2.zero ? new Vector2(-1.5f, -2.5f) : stageInfo.lastPoz;
    }
}
