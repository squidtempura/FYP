using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle, Patrol, Chase, React, Attack
}

[Serializable]
public class Parameter
{
    public int health;
    public float moveSpeed;
    public float chaseSpeed;
    public float idleTime;
    public Transform[] patrolPoints;
    public Transform[] chasePoints;

    public Transform target;
    public Animator animator;
}


public class FSM : MonoBehaviour
{
    
    public Parameter parameter;

    private IState currentState;
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();
    // Start is called before the first frame update
    void Start()
    {
        states.Add(StateType.Idle, new idleState(this));
        states.Add(StateType.Patrol, new PatrolState(this));
        states.Add(StateType.React, new ReactState(this));
        states.Add(StateType.Chase, new ChaseState(this));
        states.Add(StateType.Attack, new AttackState(this));
        
        TransitionState(StateType.Idle);
        parameter.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
    }

    public void TransitionState(StateType type)
    {
        if(currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }

    public void FlipTo(Transform target)
    {
        if(target !=null)
        {
            if(transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(-1.2f,1.2f,1.2f);
            }
            else if(transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(1.2f,1.2f,1.2f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            parameter.target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            parameter.target = null;
        }
    }
}
