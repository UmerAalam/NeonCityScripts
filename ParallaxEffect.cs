using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] float parallaxEffect;
    [SerializeField] GameObject cam;
    float startPositon,length;

    void Start()
    {
        startPositon = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPositon + distance, transform.position.y, transform.position.z);

        if (temp > startPositon + length)
            startPositon += length;
        if (temp < startPositon - length)
            startPositon -= length;
    }
}
