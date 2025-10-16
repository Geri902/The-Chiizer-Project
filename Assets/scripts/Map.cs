using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private int _width = 5;
    [SerializeField]
    private int _height = 5;
    [SerializeField]
    private GameObject _map;
    [SerializeField]
    private GameObject _wall;
    [SerializeField]
    private GameObject _explodableWall;
    private Transform _body;

    private float _increment;
    void Start()
    {
        _body = _map.transform;
        _increment = _wall.GetComponent<SpriteRenderer>().bounds.size.x;

        // need code to center camera

        GenerateMap();
    }


    void Update()
    {
        
    }

    private void GenerateMap()
    {
        float startX = _width * _increment * -1;
        float startY = _height * _increment * -1;
        Vector2 nextPos = new Vector2(startX, startY);

        for (int i = 0; i < _width + 2; i++)
        {
            MakeWall(false, nextPos);
            nextPos.x += _increment;
        }
        nextPos.x = startX;
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

            nextPos.x = startX;
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
            Instantiate(_explodableWall,pos,Quaternion.identity,_body);
        }
        else
        {
            Instantiate(_wall, pos, Quaternion.identity, _body);
        }
    }
}
