using UnityEngine;
using System.Collections;

public class EnemyPatrolState : EnemyBaseState
{
    float timeCount;

    public override void EnterState(EnemyStateManager enemy)
    {
        timeCount = 1;
        Debug.Log("patrol state");
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        //Moving
        enemy.transform.Translate(Vector2.up * Time.deltaTime);

        //Rotate enemy
        timeCount -= Time.deltaTime;
        if (timeCount >= 0) return;
        Rotate(0, 361, enemy.transform);
        timeCount = 2;
    }
    public override void OnTriggerEnter(EnemyStateManager enemy, Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemy.SwitchState(enemy.inspectState);   
        }
    }

    public override void OnTriggerExit(EnemyStateManager enemy, Collider2D collision)
    {

    }

    public override void OnTriggerStay(EnemyStateManager enemy, Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bool playerMove = collision.gameObject.GetComponent<Player>().isMove;
            if (playerMove)
            {
                enemy.SwitchState(enemy.inspectState);
            }
        }
        
    }

    void Rotate(int a, int b, Transform enemy)
    {
        enemy.transform.Rotate(0, 0, Random.Range(a, b), Space.Self);
    }



}
