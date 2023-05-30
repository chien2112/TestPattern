using System.Threading;
using UnityEngine;

public class EnemyInspectState : EnemyBaseState
{
    float timCount;
    float timeToCheck;
    public override void EnterState(EnemyStateManager enemy)
    {
        timCount = 3;
        timeToCheck = 0.5f;
        Debug.Log("inspect state");
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        timCount -= Time.deltaTime;
        if (timCount <= 0)
        {
            timCount = 3;
            enemy.SwitchState(enemy.patrolState);
        }
    }
    public override void OnTriggerEnter(EnemyStateManager enemy, Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<Player>().isMove) enemy.SwitchState(enemy.detectState);
        }
    }

    public override void OnTriggerExit(EnemyStateManager enemy, Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<Player>().isMove) enemy.SwitchState(enemy.detectState);
        }
    }

    public override void OnTriggerStay(EnemyStateManager enemy, Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timeToCheck -= Time.deltaTime;
            if (timeToCheck > 0) return;
            if (collision.GetComponent<Player>().isMove) enemy.SwitchState(enemy.detectState);
        }
        
    }

}
