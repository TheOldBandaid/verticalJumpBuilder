using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public System.Random ran = new System.Random();

    void Start()
    {
        Vector3 Spaw = new Vector3();
        Spaw.x = ran.Next(-1, 1);
        Spaw.y = ran.Next(2, 4);
    }
}
