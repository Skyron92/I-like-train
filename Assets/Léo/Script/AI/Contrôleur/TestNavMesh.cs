using UnityEngine;
using UnityEngine.AI;

public class TestNavMesh : MonoBehaviour {
    private NavMeshAgent _navMeshAgent;
    public Plane plane = new Plane(Vector3.up, 0);
    void Awake() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update() {
        MoveTest();
    }

    public void MoveTest() {
        float distance;
        if (Input.GetButtonDown("Fire1")) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance)) {
                _navMeshAgent.SetDestination(ray.GetPoint(distance));
            }
        }

        
    }
}
