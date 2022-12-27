using UnityEngine;

public class SkywardShip : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _basicSpeed = 1000f;

    private void Start() => _rigidbody = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        if (_rigidbody is null) return;

        MovingStraight();
    }

    private void MovingStraight() => _rigidbody.AddForce(transform.forward * (_basicSpeed * Time.fixedDeltaTime));
}