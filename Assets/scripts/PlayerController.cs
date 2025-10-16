using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private Vector2 _startingPosition = new Vector2(0, 0);
    [SerializeField]
    private float _speed = 1.0f;
    private InputAction _movement;
    private GameObject _player;
    
    void Start()
    {
        _player = Instantiate(_playerPrefab,_startingPosition,Quaternion.identity);
        _movement = InputSystem.actions.FindAction("Move");

    }

    
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (_movement.IsPressed())
        {
            _player.transform.Translate(_movement.ReadValue<Vector2>() * Time.deltaTime * _speed);
        }
    }
}
