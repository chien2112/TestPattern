using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class EnemyObserver : MonoBehaviour, IObserver
{
    // Enemy
    [SerializeField] Subject enemySubject;
    [SerializeField] EnemyController enemyController;
    [SerializeField] SpriteRenderer enemySprite;
    [SerializeField] Color enemyDeadColor;
    [SerializeField] GameObject note;

    [SerializeField] float currentRight;
    [SerializeField] float maxRight;
    [SerializeField] float enemyHp;

    //UI
    [SerializeField] TextMeshProUGUI txtHp;
    [SerializeField] RectTransform hpValueSlider;
    [SerializeField] RectTransform hpHolder;

    //Sound
    [SerializeField] AudioClip idleSound;
    [SerializeField] AudioClip hurtSound;
    [SerializeField] AudioClip dieSound;
    AudioSource audioSource;

    //Actions data
    Dictionary<EnemyAction, Action> enemyActionHandlers;

    private void Awake()
    {
        Debug.Log("awake");
        audioSource = GetComponent<AudioSource>();
        enemySprite = enemySubject.GetComponent<SpriteRenderer>();
        enemyController = enemySubject.GetComponent<EnemyController>();

        maxRight = hpHolder.rect.width;
        currentRight = 0;

        enemyActionHandlers = new Dictionary<EnemyAction, Action>()
        {
            {EnemyAction.Idle, EnemyIdle},
            {EnemyAction.Hurt, EnemyHurt},
            {EnemyAction.Die, EnemyDie}
        };
    }
    private void OnEnable()
    {
        enemySubject.AddObserver(this);
    }
    private void OnDisable()
    {
        enemySubject.RemoveObserver(this);
    }
    public void OnNotify(EnemyAction action)
    {
        if(enemyActionHandlers.ContainsKey(action))
        {
            enemyActionHandlers[action].Invoke();
        }
    }

    #region enemy actions
    void EnemyIdle()
    {
        audioSource.clip = idleSound; audioSource.loop = true; audioSource.Play();
    }
    void EnemyHurt()
    {
        audioSource.clip = hurtSound; audioSource.loop = false; audioSource.Play();
        note.SetActive(false);

        //Update UI
        if (enemyController.Hp == 0)
        {
            currentRight = maxRight;
        }
        else
        {
            currentRight += maxRight * enemyController.Dmg / enemyController.MaxHp;
            Debug.Log(currentRight);
        }
        hpValueSlider.offsetMax = new Vector2(-currentRight, 0);

        enemyHp = enemyController.MaxHp * (1 - currentRight / maxRight);
        txtHp.text = enemyHp.ToString() + "/100";
    }
    void EnemyDie()
    {
        audioSource.clip = dieSound; audioSource.volume = 0.3f; audioSource.loop = false; audioSource.Play();
        enemySprite.color = enemyDeadColor;
    }
    #endregion

}
