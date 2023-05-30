using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    public string enemyName;
    public Transform enemySpawnTarget;
    public GameObject enemyFactory;

    Vector3 spawnPoint;

    private void Start()
    {
        enemyName = "RANGED_NORMAL";
    }
    public void CreateSelectedEnemy()
    {
        spawnPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spawnPoint.z = 1;

        AbstractEnemyFactory enemyFactoryScript = enemyFactory.GetComponent<AbstractEnemyFactory>();
        Destroy(enemyFactoryScript);
        if (enemyName.EndsWith("NORMAL"))
        {
            enemyFactoryScript = enemyFactory.AddComponent<NormalEnemyFactory>();
        }
        else if (enemyName.EndsWith("BOSS"))
        {
            enemyFactoryScript = enemyFactory.AddComponent<BossEnemyFactory>();
        }

        enemyFactoryScript.CreateEnemy(spawnPoint, enemySpawnTarget, ref enemyName);
    }

    //button
    public void ToggleSelected(string name)
    {
        enemyName = name;
    }
    

}


