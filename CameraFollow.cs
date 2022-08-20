using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float cameraLerp;

    private void LateUpdate()
    {
        CameraX();
    }
    void CameraX()
    {
        transform.position = Vector2.Lerp(transform.position,player.transform.position, cameraLerp * Time.deltaTime);
    }

}
