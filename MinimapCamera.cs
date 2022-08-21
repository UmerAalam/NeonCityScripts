﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        Vector3 newPos = player.transform.position;
        Quaternion rot = Quaternion.Euler(0,0,0);
        transform.rotation = rot
    }
}
