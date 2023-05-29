using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDamage : IDoDamage
{
    public void DoDamage(float dmg, CircleEnemy enemy)
    {
        enemy.TakeDamage(dmg);
    }
}
