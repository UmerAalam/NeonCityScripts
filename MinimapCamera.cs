using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform player;
    Quaternion setRotation;

    private void Start()
    {
        setRotation = transform.rotation;
    }

    void LateUpdate()
    {
        Vector3 newPos = player.transform.position;
        transform.rotation = setRotation;
    }
}
