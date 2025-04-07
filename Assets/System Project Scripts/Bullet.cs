using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public WeaponSwitcher weaponswitcher;
    public float speed = 4;
    public float hitDistance = 0.2f;
    public Transform target;
    

    void Start()
    {

        Destroy(gameObject, 8);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        transform.position += transform.up * speed * Time.deltaTime;

        float distance = Vector2.Distance(transform.position, target.position);
        if (target != null)
        {
            if (distance < hitDistance)
            {
                Debug.Log("Hit!");
                Destroy(gameObject);

                if (weaponswitcher != null)
                {
                    weaponswitcher.HitTimes();
                }
            }
        }
            
        
    }
}
