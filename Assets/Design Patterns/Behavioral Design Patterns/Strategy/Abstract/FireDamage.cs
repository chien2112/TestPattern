using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : IDoDamage
{
    public void DoDamage(float dmg, CircleEnemy enemy)
    {
        enemy.TakeDamage(dmg, 10f);
    }
}
