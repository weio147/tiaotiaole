﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public PlayerControl player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x, 0, transform.position.z);
    }
}
