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
    [SerializeField]
    private float _camera_follow_distance = 3.0f;
    [SerializeField]
    private GameObject _camerObj;
    private Camera _camera;
    private InputAction _movement;
    private GameObject _player;
    private Transform _playerBody;
    
    void Start()
    {
        _camera = _camerObj.GetComponent<Camera>();
        _player = Instantiate(_playerPrefab,_startingPosition,Quaternion.identity);
        _movement = InputSystem.actions.FindAction("Move");
        _playerBody = _player.transform.Find("Body");

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

            Vector2 playerV2 = _playerBody.position;
            Vector2 camV2 = _camerObj.transform.position;

            Debug.Log(Vector2.Distance(playerV2,camV2));
            if (Vector2.Distance(playerV2,camV2) > _camera_follow_distance)
            {
                _camerObj.transform.Translate(_movement.ReadValue<Vector2>() * Time.deltaTime * _speed);
            }
        }
    }
}
