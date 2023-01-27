using System;
using Unity.VisualScripting;
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
        if(CurrentState.IsDone) CurrentState.SwitchState(CurrentState.CheckNecessity());
        CurrentState.Do();
    }
    
    /*public float CheckPatroilNecessity() {
        AnimationCurve PatroilCurve = AnimationCurve.Linear(Passenger.Passengers.Count, 1, 0, 0);
        return PatroilCurve.Evaluate();
    }*/

    private float CheckGatherNecessity() {
        foreach (Object obj in Object.FallenObject) {
            if (obj.TimeGrounded >= 5f) return 1;
        }
        return 0;
    }

    public float CheckWaitNecessity() {
        return !TrainIsGone ? 1 : 0;
    }
}