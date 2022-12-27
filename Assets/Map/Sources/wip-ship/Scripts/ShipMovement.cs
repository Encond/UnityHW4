using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _basicSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody is null) return;
        
        MovingStraight();
    }

    private void MovingStraight()
    {
        _rigidbody.velocity = new Vector3(-transform.position.x * (_basicSpeed * Time.fixedDeltaTime), 0f, 0f);
    }
}