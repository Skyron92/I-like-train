using UnityEngine;

public class Patroil : ControleurStates {
    public Patroil(Controler context) : base(context) {
    }

    private bool HasReachedDestination;
    private float X;
    private float Z;

    public override void SwitchState(ControleurStates controleurStates) {
        Context.CurrentState = controleurStates;
    }

    public override void Do() {
        Context.NavMeshAgent.SetDestination(SetUpDestination());
    }

    public Vector3 SetUpDestination() {
        X = Random.Range(0, 10);
        Z = Random.Range(0, 10);
        return new Vector3(X, Context.transform.position.y, Z);
    }
}