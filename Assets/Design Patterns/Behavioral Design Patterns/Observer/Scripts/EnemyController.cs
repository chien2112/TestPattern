using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Subject
{
    [SerializeField] float maxHp = 100;
    [SerializeField] float hp;
    [SerializeField] float dmg;

    [SerializeField] bool isDead;

    // Property
    public float MaxHp
    {
        get { return maxHp; }
    }
    public float Dmg
    {
        get { return dmg; }
    }
    public float Hp {
        get
        {
            return hp;
        }
        set 
        { 
            if(hp > 0)
            {
                hp = value;
            }
            else
            {
                hp = 0;
                Die();
            }
        } 
    }

    private void Awake()
    {
        hp = maxHp;
        dmg = 20;
        isDead = false;
    }
    private void Start()
    {
        NotifyObserver(EnemyAction.Idle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isDead)
        {
            NotifyObserver(EnemyAction.Hurt);
            Damage();     
        }
    }
    public void Damage()
    {
        Hp -= Dmg;
        Hp = Hp;
    }
    public void Die()
    {
        if (!isDead)
        {
            NotifyObserver(EnemyAction.Die);
            isDead = true;
        }
    }
}

public enum EnemyAction
{
    Idle,
    Hurt,
    Die
}
