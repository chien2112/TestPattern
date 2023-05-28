using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemyFactory : MonoBehaviour
{
    public abstract void CreateEnemy(Vector3 spawnPoint, Transform parent, ref string enemyName);
}
