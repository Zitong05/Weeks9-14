using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Spawner : MonoBehaviour
{
    public WeaponSwitcher weaponswitcher;
    public GameObject bulletPrefab;
    public Transform target;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

           
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.target = target;
            bulletScript.weaponswitcher = weaponswitcher;

        }
    }
}

