using UnityEngine;

public class PlayerMovementController : MonoBehaviour 
{
    private float _movementSpeed;

    private float _horizontalInput;
    private float _verticalInput;
    
    private Vector2 _inputVector;
    
    private Vector2 _movement;
    private Vector2 _currentPos;
    private Vector2 _newPos;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _movementSpeed = gameObject.GetComponent<Player>().MovementSpeed;
    }

    private void Update()
    {
        _inputVector = GetMovementInput();
    }

    private void FixedUpdate()
    {
        _newPos = GetNewPosition();
        _rigidbody.MovePosition(_newPos);
    }

    private Vector2 GetMovementInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        return new Vector2(_horizontalInput, _verticalInput);
    }

    private Vector2 GetNewPosition() 
    {
        _currentPos = _rigidbody.position;

         return _currentPos + _inputVector * _movementSpeed * Time.deltaTime;
    }
}