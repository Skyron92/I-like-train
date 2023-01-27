using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControleurStates : MonoBehaviour {

    protected Controler Context;
    public bool IsDone;

    protected ControleurStates(Controler context) {
        Context = context;
    }

    public ControleurStates CheckNecessity() {
        //float value = Mathf.Max(Context.CheckPatroilNecessity(), Context.CheckWaitNecessity());
        //if (value == Context.CheckPatroilNecessity()) return new Patroil(Context);
        //if (value == Context.CheckWaitNecessity()) return new Wait(Context);
        return new Wait(Context);
    }
    public abstract void SwitchState(ControleurStates controleurStates);
    public abstract void Do();
}