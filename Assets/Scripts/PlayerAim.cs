using UnityEngine;

class PlayerAim : MonoBehaviour 
{
    [SerializeField]
    private Camera _camera;
    private Rigidbody2D _rigidbody;

    private Vector2 _mousePosition;
    private Vector2 _playerPosition;
    private Vector2 _lookDirection;

    private float _angleToRotate;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        _playerPosition = _rigidbody.position;
        _lookDirection = _mousePosition - _playerPosition;

        _angleToRotate = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
        
        _rigidbody.rotation = _angleToRotate;
    }
}