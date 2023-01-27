using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Passenger : MonoBehaviour {
    public static List<Passenger> Passengers = new List<Passenger>();
    [SerializeField] private int FriendshipValue;
    private List<Passenger> Friends = new List<Passenger>();

    private void Awake() {
        Passengers.Add(this);
        foreach (Passenger passenger in Passengers) {
            if(passenger.FriendshipValue == FriendshipValue) Friends.Add(passenger);
        }
    }

    private void Update() {

    }
}