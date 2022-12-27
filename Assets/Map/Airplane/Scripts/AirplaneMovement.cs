using UnityEngine;

namespace Map.Airplane.Scripts
{
    public class AirplaneMovement : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private float _currentSpeed;

        [SerializeField] private float _basicSpeed;
        [SerializeField] private float _boostSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _riseSpeed;
        [SerializeField] private float _torqueForce;


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _currentSpeed = _basicSpeed;
        }

        private void FixedUpdate()
        {
            if (_rigidbody is null) return;

            // Straight / Forward
            InfiniteFlight();

            // Up/Down
            MovementTo(transform.right, _riseSpeed, new KeyCode[2] { KeyCode.W, KeyCode.S }, false);
            // Left/Right
            MovementTo(transform.up, _rotationSpeed, new KeyCode[2] { KeyCode.A, KeyCode.D }, true);
            // Angles
            MovementTo(transform.forward, _torqueForce, new KeyCode[2] { KeyCode.Q, KeyCode.E }, false);

            SpeedBoost();
        }

        private void InfiniteFlight() =>
            _rigidbody.velocity = transform.forward * (_currentSpeed * Time.fixedDeltaTime);

        private void MovementTo(Vector3 direction, float speed, KeyCode[] keyCodes, bool invertDirection)
        {
            Vector3 tempDirection = direction * (speed * Time.fixedDeltaTime);
            
            if (Input.GetKey(keyCodes[0]))
            {
                if (invertDirection)
                    tempDirection = -tempDirection;

                _rigidbody.AddTorque(tempDirection);
            }
            else if (Input.GetKey(keyCodes[1]))
            {
                if (!invertDirection)
                    tempDirection = -tempDirection;

                _rigidbody.AddTorque(tempDirection);
            }
        }

        private void SpeedBoost() => _currentSpeed = Input.GetKey(KeyCode.LeftShift) ? _boostSpeed : _basicSpeed;
    }
}