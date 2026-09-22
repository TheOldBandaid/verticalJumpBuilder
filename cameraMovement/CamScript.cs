using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    Sprite sky, skyObjects, background;
    GameObject player;

    public int playerPosition(GameObject player) {
        int y = Convert.ToInt32(player.transform.position.y);
        return y;
    }

    void Update()
    {
    }
}
