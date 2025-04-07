using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    public float speedx = 5;
    public float speedy = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speedx * Time.deltaTime;
        pos.y += speedy * Time.deltaTime;

        Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);

        if ( pos.x < 0 || screenPos.x > Screen.width)
        {
            speedx = speedx * -1;
        }

        if ( screenPos.y < 0 || screenPos.y > Screen.height)
        {
            speedy = speedy * -1.0001f;
        }

        transform.position = pos;
    }
}
