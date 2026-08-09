using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    void Start()
    {
        for (int i = 0 ; i < 10; i++)
        {
            GameObject obj = GetComponent<block>().gameObject;
            obj.transform.position = new Vector2(i, i);
        }
    }
}
