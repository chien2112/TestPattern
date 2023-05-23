using UnityEngine;

public class EnemyDetectState : EnemyBaseState
{
    float timeCount;
    public override void EnterState(EnemyStateManager enemy)
    {
        timeCount = 1;
        Debug.Log("detect state");
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        timeCount -= Time.deltaTime;

        enemy.transform.Rotate(0, 0, 30, Space.Self);

        if (timeCount <= 0)
        {
            enemy.SwitchState(enemy.patrolState);
        }

    }
    public override void OnTriggerEnter(EnemyStateManager enemy, Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().DestroyPlayer();
        }
    }

    public override void OnTriggerExit(EnemyStateManager enemy, Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().DestroyPlayer();
        }
    }

    public override void OnTriggerStay(EnemyStateManager enemy, Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().DestroyPlayer();
        }
        
    }

}


