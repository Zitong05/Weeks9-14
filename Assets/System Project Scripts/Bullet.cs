using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1;
    

    void Start()
    {

        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.x = speed;

        transform.position += transform.up * speed * Time.deltaTime;
    }
}
