using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private int _width = 9;
    [SerializeField]
    private int _height = 9;
    [SerializeField]
    private GameObject _map;
    [SerializeField]
    private GameObject _wall;
    [SerializeField]
    private GameObject _explodableWall;
    [SerializeField]
    private GameObject _camerObj;
    private Camera _camera;
    private Transform _body;

    private float _increment;
    void Start()
    {
        _body = _map.transform;
        _increment = _wall.GetComponent<SpriteRenderer>().bounds.size.x;
        _camera = _camerObj.GetComponent<Camera>();

        GenerateMap();
        SetCamera();
    }


    void Update()
    {
        
    }

    private void GenerateMap()
    {
        Vector2 nextPos = new Vector2(0, 0);

        for (int i = 0; i < _width + 2; i++)
        {
            MakeWall(false, nextPos);
            nextPos.x += _increment;
        }
        nextPos.x = 0;
        nextPos.y += _increment;

        for (int i = 0; i < _height; i++)
        {
            MakeWall(false, nextPos);
            nextPos.x += _increment;
            for (int j = 0; j < _width; j++)
            {
                if (j % 2 != 0 && i % 2 != 0)
                {
                    MakeWall(false, nextPos);                    
                }
                nextPos.x += _increment;
            }
            MakeWall(false, nextPos);
            nextPos.x += _increment;

            nextPos.x = 0;
            nextPos.y += _increment;
        }

        for (int i = 0; i < _width + 2; i++)
        {
            MakeWall(false, nextPos);
            nextPos.x += _increment;
        }

    }

    private void MakeWall(bool explodable, Vector2 pos)
    {
        if (explodable)
        {
            Instantiate(_explodableWall, pos, Quaternion.identity, _body);
        }
        else
        {
            Instantiate(_wall, pos, Quaternion.identity, _body);
        }
    }
    
    private void SetCamera()
    {
        _camerObj.transform.position = new Vector3(1,1,-10);
        //_camerObj.transform.position = new Vector3(_width * _increment / 2 + 0.5f, _height * _increment / 2 + 0.5f, -10);
        
    }
}
