using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _grassTile, _mountianTile;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;

    void Awake()
    {
        Instance = this;
    }


    public void GenerateGird()
    {
        _tiles = new Dictionary<Vector2,Tile>();
        for(int  x = 0; x < _width; x++) 
        {
            for(int y = 0; y < _height; y++) 
            {
                var randomTile = Random.Range(0,6) == 3 ? _mountianTile : _grassTile;
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.Init(x,y);
                _tiles[new Vector2(x,y)] = spawnedTile;
            }
                
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);

        GameManager.Instance.ChangeState(GameState.SpawnPlayer);
    }

    public Tile GetPlayerTile()
    {
        return _tiles.Where(t=>t.Key.x <  _width/2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

        public Tile GetEnemyTile()
    {
        return _tiles.Where(t=>t.Key.x >  _width/2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }
}