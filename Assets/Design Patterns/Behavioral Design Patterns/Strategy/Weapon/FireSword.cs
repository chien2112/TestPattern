using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSword : BaseWeapon
{
    public FireSword()
    {
        damage = 10;
        dmgType = new FireDamage();
    }
}
