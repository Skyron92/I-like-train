using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Passenger : MonoBehaviour {
    public static List<Passenger> Passengers = new List<Passenger>();
    public static List<Passenger> ControlledPassengers = new List<Passenger>();
    public bool IsControlled;
    public bool IsInRules;

    private void Awake() {
        Passengers.Add(this);
        ControlledPassengers.Add(this);
    }

    private void Update() {
        if (IsControlled) ControlledPassengers.Remove(this);
        
    }
}