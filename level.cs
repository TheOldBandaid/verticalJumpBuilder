using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class level : MonoBehaviour
{
    public stage stageInfo;
    public Vector2 Position()
    {
        Vector2 position = stageInfo.lastPoz == Vector2.zero ? new Vector2(-1.5f, -2.5f) : stageInfo.lastPoz;
        return position;
    }
}
