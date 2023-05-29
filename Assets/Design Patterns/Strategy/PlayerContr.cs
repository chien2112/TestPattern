using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContr : MonoBehaviour
{
    public BaseWeapon fireSword;
    public BaseWeapon basicSword;
    public BaseWeapon currentWeapon;
    public bool isSwitch;
    private void Start()
    {
        currentWeapon = basicSword;
        isSwitch = false;
    }
    void Update()
    {
        Attack();
        SwitchWeapon();
    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.DoAttack();
        }
    }
    void SwitchWeapon()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isSwitch)
            {
                fireSword.gameObject.SetActive(true);
                basicSword.gameObject.SetActive(false);
                isSwitch = !isSwitch;
                currentWeapon = fireSword;

            }
            else
            {
                fireSword.gameObject.SetActive(false);
                basicSword.gameObject.SetActive(true);
                isSwitch = !isSwitch;
                currentWeapon = basicSword;
            }
        }   
    }
    
}
