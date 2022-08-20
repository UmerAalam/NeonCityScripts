using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float cameraLerp;
    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        CameraX();
    }
    void CameraX()
    {
        transform.position = Vector2.Lerp(transform.position + offset,player.transform.position, cameraLerp * Time.deltaTime);
    }

}
