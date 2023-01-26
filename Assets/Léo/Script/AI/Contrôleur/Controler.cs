using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controler : MonoBehaviour {
    [HideInInspector] public ControleurStates CurrentState;
    private Animator _animator;
    [SerializeField] private bool TrainIsGone;
    public NavMeshAgent NavMeshAgent { get; private set; }
    

    private void Awake() {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        CurrentState = new Wait(this);
    }

    private void Update() {
        CurrentState.SwitchState(CurrentState.CheckNecessity());
        CurrentState.Do();
    }

    public float CheckPatroilNecessity() {
        AnimationCurve PatroilCurve = AnimationCurve.Linear(Passenger.Passengers.Count, 1, 0, 0);
        return PatroilCurve.Evaluate(Passenger.ControlledPassengers.Count);
    }

    public float CheckWaitNecessity() {
        return !TrainIsGone ? 1 : 0;
    }
    
}