using Photon.Pun;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour 
{
    private float _movementSpeed;

    private float _horizontalInput;
    private float _verticalInput;
    
    private Vector2 _inputVector;
    
    private Vector2 _currentPos;
    private Vector2 _newPos;

    private Rigidbody2D _playerRigidbody;
    private PhotonView _view;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _movementSpeed = gameObject.GetComponent<Player>().MovementSpeed;
        _view  = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if(_view.IsMine)
        {
            _inputVector = GetMovementInput();
        }
    }

    private void FixedUpdate()
    {
        if (_view.IsMine)
        {
            _newPos = GetNewPosition();
            _playerRigidbody.MovePosition(_newPos);
        }
    }

    private Vector2 GetMovementInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        return new Vector2(_horizontalInput, _verticalInput);
    }

    private Vector2 GetNewPosition() 
    {
        _currentPos = _playerRigidbody.position;

         return _currentPos + _inputVector * _movementSpeed * Time.deltaTime;
    }
}