using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleParallax : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        transform.position = startPos;
    }
    void FixedUpdate()
    {
        float cameraX = Camera.main.transform.position.x;
        transform.position = new Vector3(cameraX * moveSpeed,transform.position.y,transform.position.z);
    }
}
