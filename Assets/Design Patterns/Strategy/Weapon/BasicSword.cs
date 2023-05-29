using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSword : BaseWeapon
{
    public BasicSword()
    {
        damage = 30;
        dmgType = new NormalDamage();
    }
}
