using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtState;
    EnemyBaseState currentState;
    public EnemyDetectState detectState = new EnemyDetectState();
    public EnemyInspectState inspectState = new EnemyInspectState();
    public EnemyPatrolState patrolState = new EnemyPatrolState();
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = patrolState;
        currentState.EnterState(this);
        txtState.text = currentState.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    //Switch state
    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
        txtState.text = state.ToString(); 
        Debug.Log(txtState.text);
    }


    //Events
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter(this, collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        currentState.OnTriggerExit(this, collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        currentState.OnTriggerStay(this, collision);
    }
}
