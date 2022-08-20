using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float moveTime;
    [SerializeField] Vector3 endPos;
    Vector3 startPos;
    bool isPlayer;
    private void Start()
    {
        isPlayer = false;
        startPos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayer = true;
    }
    private void Update()
    {
        if (isPlayer)
            MovePlatform();
    }
    void MovePlatform()
    {
        transform.position = Vector3.Lerp(startPos,endPos,moveTime * Time.deltaTime);
    }
}
