using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    private Animator _animator;
    private float timer;

    void Awake() {
        player.Doors.Add(this);
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_animator.enabled) {
            timer += Time.deltaTime;
        }

        if (timer >= 7.5f) {
            _animator.enabled = false;
            timer = 0;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, player.Range);
    }
}
