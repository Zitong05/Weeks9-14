using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelaySpawner : MonoBehaviour
{
    public GameObject Bullet;
    public float delay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(DelayedInstantiate());
        }
        
    }

    IEnumerator DelayedInstantiate()
    {
        yield return new WaitForSeconds(delay); 
        
        Instantiate(Bullet, transform.position, transform.rotation);  
    }
}
