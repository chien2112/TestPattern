using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyFactory : AbstractEnemyFactory
{

    public override void CreateEnemy(Vector3 spawnPoint, Transform parent, ref string enemyName)
    {
        if (enemyName.StartsWith("RANGED"))
        {
            var enemySpawn = Resources.Load("Factory/Close_Range_Boss") as GameObject;

            if (enemySpawn != null)
            {
                Instantiate(enemySpawn, spawnPoint, Quaternion.identity, parent);
            }
            else
            {
                throw new System.ArgumentException(enemySpawn + "could not be found inside or loaded from Resources folder");
            }
        }
        else if (enemyName.StartsWith("CLOSE"))
        {
            var enemySpawn = Resources.Load("Factory/Ranged_Boss") as GameObject;

            if (enemySpawn != null)
            {
                Instantiate(enemySpawn, spawnPoint, Quaternion.identity, parent);
            }
            else
            {
                throw new System.ArgumentException(enemySpawn + "could not be found inside or loaded from Resources folder");
            }
        }
        else
        {
            Debug.Log("enemyName == null");
        }
    }
}
