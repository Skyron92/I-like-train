using UnityEngine;

public class Wait : ControleurStates {
    public Wait(Controler context) : base(context) {
    }

    public override void SwitchState(ControleurStates controleurStates) {
        Context.CurrentState = controleurStates;
    }

    public override void Do() {
        
    }
}