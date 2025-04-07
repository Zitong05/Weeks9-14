using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public List<GameObject> Weapons; // �ѳ����е�4��ǹ���Ͻ���
    private int currentGunIndex = 0;
    private int hitCounter = 0;
    private const int hitsToSwitch = 5;

    void Start()
    {
        ActivateGun(currentGunIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HitTimes()
    {
        hitCounter++;
        Debug.Log("���м���: " + hitCounter);

        if (hitCounter >= hitsToSwitch)
        {
            hitCounter = 0;
            SwitchToNextGun();
        }
    }

    void SwitchToNextGun()
    {
        currentGunIndex = (currentGunIndex + 1) % Weapons.Count;
        ActivateGun(currentGunIndex);
    }

    void ActivateGun(int index)
    {
        for (int i = 0; i < Weapons.Count; i++)
        {
            Weapons[i].SetActive(i == index);
        }

        Debug.Log("Switched to gun: " + Weapons[index].name);
    }
}
