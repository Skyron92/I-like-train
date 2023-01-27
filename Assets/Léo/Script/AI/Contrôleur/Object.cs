using System.Collections.Generic;
using UnityEngine;

public abstract class Object : MonoBehaviour {
    public bool IsGrounded;
    public float TimeGrounded;
    public static List<Object> FallenObject = new List<Object>();

    public void Update() {
        if (IsGrounded) TimeGrounded += Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision) {
        FallenObject.Add(this);
        IsGrounded = true;
    }
}