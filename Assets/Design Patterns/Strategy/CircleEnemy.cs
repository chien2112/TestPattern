using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CircleEnemy : MonoBehaviour
{
    float timeCount = 2f;
    float _timeCount = 2f;
    public float hp = 100f;
    public GameObject fireEffect;

    private void Start()
    {
        fireEffect.SetActive(false);
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        //Moving
        transform.Translate(Vector2.up * Time.deltaTime);

        //Rotate enemy
        _timeCount -= Time.deltaTime;
        if (_timeCount >= 0) return;
        Rotate(0, 361, transform);
        _timeCount = timeCount;
    }
    void Rotate(int a, int b, Transform enemy)
    {
        enemy.transform.Rotate(0, 0, Random.Range(a, b), Space.Self);
    }

    public void TakeDamage(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            
        }
        if (hp < 0)
        {
            hp = 0;
            StopAllCoroutines();
            Destroy(this.gameObject);            
        }
        if(hp == 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage(float damage, float time)
    {
        StartCoroutine(TakeDamageOverTime(damage));
        if (fireEffect.activeSelf)
        {
            fireEffect.transform.localScale *= 1.5f;
        }
        fireEffect.SetActive(true);
    }
    IEnumerator TakeDamageOverTime(float damage)
    {
        yield return new WaitForSeconds(1f);
        TakeDamage(damage);
        Debug.Log("hot");
        StartCoroutine(TakeDamageOverTime(damage));
        
    }
}
