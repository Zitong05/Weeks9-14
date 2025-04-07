using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    public float speed = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;

        Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);

        if ( pos.x < -5 || screenPos.x > Screen.width)
        {
            speed = speed * -1;
        }
        transform.position = pos;
    }
}
